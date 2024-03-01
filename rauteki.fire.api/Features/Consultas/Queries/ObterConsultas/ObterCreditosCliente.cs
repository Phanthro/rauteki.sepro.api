using AutoMapper;
using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;

namespace Rauteki.Fire.Api.Features.Consultas.Queries.ObterConsultas;

public class ObterConsultas
{

    public record Query() : IQuery<IEnumerable<ObterConsultasDto>>;

    public class Handler : IRequestHandler<Query, IEnumerable<ObterConsultasDto>>
    {
        private readonly IConsultaRepository _consultaRepo;
        private readonly IMapper _mapper;

        public Handler(IConsultaRepository consultaRepo, IMapper mapper)
        {
            _consultaRepo = consultaRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ObterConsultasDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var dbResult = await _consultaRepo.ObterConsultas();

            IEnumerable<ObterConsultasDto> consultas = dbResult.Select((a)=>new ObterConsultasDto{
                ConsultaId = a.ConsultaId,
                Descricao = a.Descricao,
                Nome = a.Nome,
                Valor = a.Valor,
                Link = a.Link,
                ItemPai = a.ItemPai
            });

            return consultas;
            
        }
    }

}