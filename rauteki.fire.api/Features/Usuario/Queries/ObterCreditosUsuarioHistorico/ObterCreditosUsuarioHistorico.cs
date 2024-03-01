using AutoMapper;
using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;

namespace Rauteki.Fire.Api.Features.Usuario.Queries.ObterCreditosUsuarioHistorico;

public class ObterCreditosUsuarioHistorico
{

    public record Query(int UsuarioId) : IQuery<IEnumerable<ObterCreditosUsuarioHistoricoDto>>;

    public class Handler : IRequestHandler<Query, IEnumerable<ObterCreditosUsuarioHistoricoDto>>
    {
        private readonly IUsuarioRepository _UsuarioRepo;
        private readonly IMapper _mapper;

        public Handler(IUsuarioRepository UsuarioRepo, IMapper mapper)
        {
            _UsuarioRepo = UsuarioRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ObterCreditosUsuarioHistoricoDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var dbResult = await _UsuarioRepo.ObterCreditoUsuarioHistorico(request.UsuarioId);

            IEnumerable<ObterCreditosUsuarioHistoricoDto> result = dbResult.Select((a)=>new ObterCreditosUsuarioHistoricoDto{
                UsuarioId = a.UsuarioId,
                UsuarioNome = a.UsuarioNome,
                EfetuadoEm = a.EfetuadoEm,
                Valor = a.Valor
            });

            return result;
            
        }
    }

}