using AutoMapper;
using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;
using Rauteki.Fire.Api.Services.Interfaces;
using Rauteki.Fire.Api.Misc;
using Newtonsoft.Json;
using Rauteki.Fire.Api.Repositories.Model;

namespace Rauteki.Fire.Api.Features.CND.Commands.ConsultaCND;

public class ConsultaCND
{

    public record Query(ConsultaCNDDto Dados) : IQuery<Retorno>;

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
            ConsultasEnum tipo = ConsultasEnum.CND;

            var consulta = consultas.Where(x => x.ConsultaId == (int)tipo).FirstOrDefault();

            if (consulta == null) throw new Exception("Tipo de Consulta não encontrada");

            if (creditos < consulta.Valor) throw new Exception("Creditos insuficientes.");

            string jsonRequest = JsonConvert.SerializeObject(request.Dados);

            try
            {
                var res = await _FireIntegracao.CND(jsonRequest);

                await _consultaRepo.SalvarConsultaHistorico(request.Dados.UsuarioId, consulta.ConsultaId, request.Dados.ContribuinteConsulta.ToString(), jsonRequest, res);
                await _usuarioRepo.AtualizaCreditoUsuario(request.Dados.UsuarioId, creditos - consulta.Valor);
                await _usuarioRepo.SalvarConsultaHistorico(request.Dados.UsuarioId, consulta.Valor, (int)TipoOperacaoEnum.Debito);


                if (string.IsNullOrEmpty(res)) throw new Exception("Consulta sem retorno");

                ConsultaCNDResultadoDto consultaCNDResultado
                    = JsonConvert.DeserializeObject<ConsultaCNDResultadoDto>(res)
                        ?? new ConsultaCNDResultadoDto();

                TratarRetorno(consultaCNDResultado);

                Retorno retorno = new(consultaCNDResultado);
                return retorno;


            }
            catch (System.Exception ex)
            {
                Retorno retorno = new(ex.Message, 999);
                return retorno;
            }

        }

        private void TratarRetorno(ConsultaCNDResultadoDto item)
        {
            item.Certidao.TipoContribuinte
                = item.Certidao.TipoContribuinte switch
                {
                    "1" => "Pessoa Juridica",
                    "2" => "Pessoa Física",
                    "3" => "Imóvel Rural",
                    _ => item.Certidao.TipoContribuinte
                };

            item.Certidao.TipoCertidao = item.Certidao.TipoCertidao == "1" ? "Negativa" : "Positiva com efeitos de negativa";
        }
     
    }

}