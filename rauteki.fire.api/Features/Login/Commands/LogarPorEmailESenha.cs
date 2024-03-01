using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Rauteki.Fire.Api.Features.Login.Commands.LogarPorEmailESenha;

public class LogarPorEmailESenha
{

    public record Command(string EmailESenhaDto) : ICommand<UsuarioPorEmailDto>;

    public class Handler : LogarPorEmailESenhaDtoValidator, IRequestHandler<Command, UsuarioPorEmailDto>
    {
        private readonly IUsuarioRepository _userRepo;
        private readonly IConfiguration _configuration;

        public Handler(IUsuarioRepository userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }

        public async Task<UsuarioPorEmailDto> Handle(Command request, CancellationToken cancellationToken)
        {
            Validate(request);
            
            Commands.LogarPorEmailESenha.LogarPorEmailESenhaDto dadosLogin = ObterCredentials(request.EmailESenhaDto);

            try
            {
                UsuarioPorEmailDto? usuario = await _userRepo.ObterPorEmail(dadosLogin);

                // Verifique se o usuário existe e a senha está correta
                if (usuario == null || !BCrypt.Net.BCrypt.Verify(dadosLogin.Senha, usuario.Senha))
                {
                    throw new Exception("Erro ao Logar");
                }

                var permissoesPagina =  await _userRepo.ObterPermissoesPaginaUsuario(usuario.UsuarioId);
                usuario.Permissoes = permissoesPagina.Select(x=>x.PaginaId);
                
                // JWT Payload
                var claims = new[]
                {
                    new Claim("username", usuario.Nome),
                    new Claim("e-mail", usuario.Email),
                    new Claim("usuarioId", usuario.UsuarioId.ToString()),
                    new Claim("clienteId", usuario.ClienteId.ToString()),
                    new Claim("permissoes", JsonConvert.SerializeObject(usuario.Permissoes))
                };

                string? jwtKey = _configuration["Jwt:Key"] ?? throw new Exception("Erro JWT");

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: creds);

                usuario.Token = new JwtSecurityTokenHandler().WriteToken(token);
                usuario.ValidTo = token.ValidTo;

                return  usuario;

            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao Logar" + ex.Message);
            }


        }

        public LogarPorEmailESenhaDto ObterCredentials(string authHeader) {

            if (!string.IsNullOrEmpty(authHeader)) {
                
                var parts = authHeader.Split(' ');
                
                if (parts.Length == 2 && parts[0].ToLower() == "basic")
                {
                    var decodedBytes = Convert.FromBase64String(parts[1]);
                    string decoded = Encoding.UTF8.GetString(decodedBytes);
                    var creds = decoded.Split(':');
                    
                    return new LogarPorEmailESenhaDto(){Email = creds[0], Senha = creds[1]};

                } else {
                    throw new Exception("Erro ao logar");
                }
            } else {
                throw new Exception("Erro ao logar");
            }

        }

    }
}