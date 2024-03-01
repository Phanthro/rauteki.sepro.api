using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;

namespace Rauteki.Fire.Api.Features.Cliente.Queries.ObterCreditosCliente;

public class ObterCreditosCliente
{

    public record Query(int ClienteId) : IQuery<decimal>;

    public class Handler : IRequestHandler<Query, decimal>
    {
        private readonly IClienteRepository _clienteRepo;

        public Handler(IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public async Task<decimal> Handle(Query request, CancellationToken cancellationToken)
        {
            var dbResult = await _clienteRepo.ObterCreditoCliente(request.ClienteId);

            return dbResult;
            
        }
    }

}