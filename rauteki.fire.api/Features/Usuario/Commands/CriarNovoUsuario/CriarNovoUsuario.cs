using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;
using MySqlX.XDevAPI;
using System.Buffers.Text;

namespace Rauteki.Fire.Api.Features.Usuario.Commands.CriarNovoUsuario;

public class CriarNovoUsuario
{
    public record Command(CriarNovoUsuarioDto UsuarioDto ) : ICommand<int>;

    public class Handler : CriarNovoUsuarioDtoValidator, IRequestHandler<Command, int>
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public Handler(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public async Task<int> Handle(Command request, CancellationToken cancellationToken)
        {
            Validate(request);
            
            var bytes = Convert.FromBase64String(request.UsuarioDto.Senha);
            request.UsuarioDto.Senha = System.Text.Encoding.UTF8.GetString(bytes);
            request.UsuarioDto.Senha = BCrypt.Net.BCrypt.HashPassword(request.UsuarioDto.Senha, 10);
            var dbResult = await _usuarioRepo.CriarNovoUsuario(request.UsuarioDto);

            return await Task.FromResult(dbResult);
            
        }

    }
}