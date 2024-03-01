using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;

namespace Rauteki.Fire.Api.Features.Usuario.Commands.AlterarUsuario;

public class AlterarUsuario
{
    public record Command(AlterarUsuarioDto UsuarioDto) : ICommand<int>;

    public class Handler : AlterarUsuarioDtoValidator, IRequestHandler<Command, int>
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public Handler(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public async Task<int> Handle(Command request, CancellationToken cancellationToken)
        {
            Validate(request);
            var dbResult = await _usuarioRepo.AlterarUsuario(request.UsuarioDto);

            return await Task.FromResult(dbResult);
            
        }

    }
}