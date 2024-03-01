using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;

namespace Rauteki.Fire.Api.Features.Usuario.Queries.ObterCreditosUsuario;

public class ObterCreditosUsuario
{

    public record Query(int UsuarioId) : IQuery<decimal>;

    public class Handler : IRequestHandler<Query, decimal>
    {
        private readonly IUsuarioRepository _UsuarioRepo;

        public Handler(IUsuarioRepository UsuarioRepo)
        {
            _UsuarioRepo = UsuarioRepo;
        }

        public async Task<decimal> Handle(Query request, CancellationToken cancellationToken)
        {
            var dbResult = await _UsuarioRepo.ObterCreditoUsuario(request.UsuarioId);

            return dbResult;
            
        }
    }

}