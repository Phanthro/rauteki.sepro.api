using AutoMapper;
using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;

namespace Rauteki.Fire.Api.Features.Consultas.Queries.ObterConsultasUsuarioHistorico;

public class ObterConsultasUsuarioHistorico
{

    public record Query(int UsuarioId, int ConsultaHistoricoId) : IQuery<IEnumerable<ObterConsultasUsuarioHistoricoDto>>;

    public class Handler : IRequestHandler<Query, IEnumerable<ObterConsultasUsuarioHistoricoDto>>
    {
        private readonly IConsultaRepository _consultaRepo;
        private readonly IMapper _mapper;

        public Handler(IConsultaRepository consultaRepo, IMapper mapper)
        {
            _consultaRepo = consultaRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ObterConsultasUsuarioHistoricoDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var dbResult = await _consultaRepo.ObterConsultasUsuarioHistorico(request.UsuarioId, request.ConsultaHistoricoId);

            IEnumerable<ObterConsultasUsuarioHistoricoDto> result = dbResult.Select((a) => new ObterConsultasUsuarioHistoricoDto{

                ConsultaHistoricoId = a.ConsultaHistoricoId,
                ConsultaId = a.ConsultaId,
                Cpf = a.Cpf,
                NomeConsulta = a.NomeConsulta,
                NomeUsuario = a.NomeUsuario,
                RealizadoEm = a.RealizadoEm,
                Requisicao = a.Requisicao,
                Resposta = a.Resposta

            });

            return result;
            
        }
    }

}