using AutoMapper;
using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;

namespace Rauteki.Fire.Api.Features.Cliente.Queries.ObterCreditosClienteHistorico;

public class ObterCreditosClienteHistorico
{

    public record Query(int clienteId) : IQuery<IEnumerable<ObterCreditosClienteHistoricoDto>>;

    public class Handler : IRequestHandler<Query, IEnumerable<ObterCreditosClienteHistoricoDto>>
    {
        private readonly IClienteRepository _clienteRepo;
        private readonly IMapper _mapper;

        public Handler(IClienteRepository clienteRepo, IMapper mapper)
        {
            _clienteRepo = clienteRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ObterCreditosClienteHistoricoDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var dbResult = await _clienteRepo.ObterCreditoClienteHistorico(request.clienteId);

            IEnumerable<ObterCreditosClienteHistoricoDto> result = dbResult.Select((a)=>new ObterCreditosClienteHistoricoDto{
                ClienteId = a.ClienteId,
                ClienteNome = a.ClienteNome,
                EfetuadoEm = a.EfetuadoEm,
                UsuarioId = a.UsuarioId,
                UsuarioNome = a.UsuarioNome,
                Valor = a.Valor
            });

            return result;
            
        }
    }

}