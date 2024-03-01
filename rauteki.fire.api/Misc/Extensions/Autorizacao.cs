using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Commands = Rauteki.Fire.Api.Features.Login.Commands;

namespace Rauteki.Fire.Api.Misc.Extensions;

public static class Autorizacao
{
    public static IServiceCollection ConfiguraBearer(this IServiceCollection services, IConfiguration configuration)
    {

        string key = configuration["Jwt:Key"] ?? throw new Exception("Chave não encontrada");

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            
        })
        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicSchema", null)
        
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                // Configurações do token, como chave, emissor, audiência, etc.
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]??"Erro-na-chave"))
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    // Obter o token do cookie
                    if (context.Request.Cookies.ContainsKey("Fire-token"))
                    {
                        context.Token = context.Request.Cookies["Fire-token"];
                    }
                    return Task.CompletedTask;
                },
                OnAuthenticationFailed = context => {
                    context.Response.Cookies.Delete("Fire-token");
                    return Task.CompletedTask;
                }
            };
        });

        services.AddAuthorization(options =>
        {
     
           options.AddPolicy("BasicPolicy", policy =>
            {
                policy.AuthenticationSchemes.Add("BasicSchema");
                policy.RequireAuthenticatedUser();
            });
        });

        return services;

    }

    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly ISender _mediator;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            ISender mediator)
            : base(options, logger, encoder, clock)
        {
            _mediator = mediator;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authorization = Request.Headers["Authorization"].FirstOrDefault();
            if (String.IsNullOrEmpty(authorization))
                return AuthenticateResult.Fail("Cabeçalho de autorização ausente");

            try
            {
                Commands.LogarPorEmailESenha.UsuarioPorEmailDto usuario
                    = await _mediator.Send(new Commands.LogarPorEmailESenha.LogarPorEmailESenha.Command(authorization));

                var claims = new[] { 
                    new Claim(ClaimTypes.Name, usuario.Nome), 
                    new Claim("access-token", usuario.Token),
                    new Claim("validTo", usuario.ValidTo.ToString("yyyy-MM-ddThh:mm:ss")),
                    new Claim("permissoes", JsonConvert.SerializeObject(usuario.Permissoes))
                };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);

            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Erro ao processar a autenticação: {ex.Message}");
            }
        }
    }

}