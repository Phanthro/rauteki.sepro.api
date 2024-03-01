using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;
using Rauteki.Fire.Api.Services.Interfaces;
using Rauteki.Fire.Api.Misc;
using Newtonsoft.Json;

namespace Rauteki.Fire.Api.Features.CPF.Queries.ConsultaCPF;

public partial class ConsultaCPF
{

    public record Query(ConsultaCPFDto Dados) : IQuery<Retorno>;

    public partial class Handler : IRequestHandler<Query, Retorno>
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
            ConsultasEnum tipo = ConsultasEnum.CPF;

            var consulta = consultas.Where(x=>x.ConsultaId == (int)tipo).FirstOrDefault();

            if(consulta == null) throw new Exception("Tipo de Consulta não encontrada");

            if(creditos < consulta.Valor) throw new Exception("Creditos insuficientes.");

            string jsonRequest = JsonConvert.SerializeObject(request.Dados);
            
            try
            {
                var res = await _FireIntegracao.CPF(RemoverNaoNumericos(request.Dados.NumeroInscricao));

                await _consultaRepo.SalvarConsultaHistorico(request.Dados.UsuarioId, consulta.ConsultaId, request.Dados.NumeroInscricao.ToString(),  jsonRequest, res);
                await _usuarioRepo.AtualizaCreditoUsuario(request.Dados.UsuarioId, creditos - consulta.Valor);
                await _usuarioRepo.SalvarConsultaHistorico(request.Dados.UsuarioId, consulta.Valor, (int)TipoOperacaoEnum.Debito);


                if(string.IsNullOrEmpty(res)) throw new Exception("Consulta sem retorno");
               
                ConsultaCPFResultadoDto consultaCPFResultado 
                    = JsonConvert.DeserializeObject<ConsultaCPFResultadoDto>(res)
                        ?? new ConsultaCPFResultadoDto();
                        
                Retorno retorno = new(consultaCPFResultado);
                return retorno;
            

            }
            catch (Exception ex)
            {
                Retorno retorno = new(ex.Message, 999);
                return retorno;
            }
            
        }
        static string RemoverNaoNumericos(string input)
        {
            System.Text.RegularExpressions.Regex regex = MyRegex();
            return regex.Replace(input, "");
        }

        [System.Text.RegularExpressions.GeneratedRegex("[^0-9]")]
        private static partial System.Text.RegularExpressions.Regex MyRegex();



        // private string DeParaCodigoSituacao(string codigo)
        // {
        //     return codigo switch
        //     {
        //         "0" => "Regular",
        //         "2" => "Suspensa",
        //         "3" => "Titular Falecido",
        //         "4" => "Pendente de Regularização",
        //         "5" => "Cancelada por Multiplicidade",
        //         "8" => "Nula",
        //         "9" => "Cancelada de Ofício",
        //         _ => "Não conhecida",
        //     };
        // }
    }

}