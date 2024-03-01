using AutoMapper;
using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;
using Rauteki.Fire.Api.Services.Interfaces;
using Rauteki.Fire.Api.Misc;
using Newtonsoft.Json;
using Rauteki.Fire.Api.Repositories.Model;

namespace Rauteki.Fire.Api.Features.DividaAtiva.Queries.ConsultaDividaAtiva;

public class ConsultaDividaAtiva
{

    public record Query(ConsultaDividaAtivaDto Dados) : IQuery<Retorno>;

    public class Handler : IRequestHandler<Query, Retorno>
    {
        private readonly IFireService _FireIntegracao;
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IConsultaRepository _consultaRepo;

        public Handler(IFireService FireIntegracao, IUsuarioRepository usuarioRepo, IConsultaRepository consultaRepo)
        {
            _FireIntegracao = FireIntegracao;
            _usuarioRepo = usuarioRepo;
            _consultaRepo = consultaRepo;
        }

        public async Task<Retorno> Handle(Query request, CancellationToken cancellationToken)
        {
            decimal creditos = await _usuarioRepo.ObterCreditoUsuario(request.Dados.UsuarioId);
            IEnumerable<Repositories.Model.Consulta> consultas = await _consultaRepo.ObterConsultas();
            ConsultasEnum tipo;
            if(request.Dados.Tipo == "inscricao")
            {
                tipo = ConsultasEnum.DividaAtivaInscricao;
            }
            else
            {
                tipo = ConsultasEnum.DividaAtivaDevedor;
            }

            var consulta = consultas.Where(x=>x.ConsultaId == (int)tipo).FirstOrDefault();

            if(consulta == null) throw new Exception("Tipo de Consulta não encontrada");

            if(creditos < consulta.Valor) throw new Exception("Creditos insuficientes.");

            string jsonRequest = JsonConvert.SerializeObject(request.Dados);
            
            try
            {
                var res = await _FireIntegracao.DividaAtiva(request.Dados.Tipo, request.Dados.NumeroInscricao);

                await _consultaRepo.SalvarConsultaHistorico(request.Dados.UsuarioId, consulta.ConsultaId, request.Dados.NumeroInscricao.ToString(),  jsonRequest, res);
                await _usuarioRepo.AtualizaCreditoUsuario(request.Dados.UsuarioId, creditos - consulta.Valor);
                await _usuarioRepo.SalvarConsultaHistorico(request.Dados.UsuarioId, consulta.Valor, (int)TipoOperacaoEnum.Debito);

                if(string.IsNullOrEmpty(res)) throw new Exception("Consulta sem retorno");
                
                if(tipo == ConsultasEnum.DividaAtivaInscricao)
                {
                    IEnumerable<ConsultaDividaAtivaInscricaoResultadoDto> dividaAtivaResultado 
                        = JsonConvert.DeserializeObject<IEnumerable<ConsultaDividaAtivaInscricaoResultadoDto>>(res)
                            ?? new List<ConsultaDividaAtivaInscricaoResultadoDto>();
                    Retorno retorno = new(dividaAtivaResultado);
                    return retorno;
                }
                else
                {
                    IEnumerable<ConsultaDividaAtivaDevedorResultadoDto> dividaAtivaResultado 
                        = JsonConvert.DeserializeObject<IEnumerable<ConsultaDividaAtivaDevedorResultadoDto>>(res) 
                            ?? new List<ConsultaDividaAtivaDevedorResultadoDto>();
                    Retorno retorno = new(dividaAtivaResultado);
                    return retorno;

                }

            }
            catch (System.Exception ex)
            {
                Retorno retorno = new(ex.Message, 999);
                return retorno;
            }

            
        }
    }

}