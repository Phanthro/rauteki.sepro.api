using AutoMapper;
using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;
using Rauteki.Fire.Api.Services.Interfaces;
using Rauteki.Fire.Api.Misc;
using Newtonsoft.Json;
using Rauteki.Fire.Api.Repositories.Model;
using System.Text.RegularExpressions;

namespace Rauteki.Fire.Api.Features.CNPJ.Queries.ConsultaCNPJ;

public partial class ConsultaCNPJ
{

    public record Query(ConsultaCNPJDto Dados) : IQuery<Retorno>;

    public partial class Handler : IRequestHandler<Query, Retorno>
    {
        private readonly IFireService _FireIntegracao;
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IConsultaRepository _consultaRepo;
        private readonly IMapper _mapper;
        private readonly IDominioRepository _dominioRepo;
        private IEnumerable<Dominio> listaDominios = new List<Dominio>();

        public Handler(IFireService FireIntegracao, IMapper mapper, IUsuarioRepository usuarioRepo, IConsultaRepository consultaRepo, IDominioRepository dominioRepo)
        {
            _dominioRepo = dominioRepo;
            _FireIntegracao = FireIntegracao;
            _usuarioRepo = usuarioRepo;
            _consultaRepo = consultaRepo;
            _mapper = mapper;
        }

        public async Task<Retorno> Handle(Query request, CancellationToken cancellationToken)
        {
            decimal creditos = await _usuarioRepo.ObterCreditoUsuario(request.Dados.UsuarioId);
            IEnumerable<Consulta> consultas = await _consultaRepo.ObterConsultas();
            ConsultasEnum tipo;
            if(request.Dados.Tipo == "basica")
            {
                tipo = ConsultasEnum.CNPJBasica;
            }
            else if(request.Dados.Tipo == "qsa")
            {
                tipo = ConsultasEnum.CNPJqsa;
            }
            else if(request.Dados.Tipo == "empresa")
            {
                tipo = ConsultasEnum.CNPJEmpresa;
            }
            else
            {
                throw new Exception("Tipo de consulta não definido");
            }

            var consulta = consultas.Where(x=>x.ConsultaId == (int)tipo).FirstOrDefault();

            if(consulta == null) throw new Exception("Tipo de Consulta não encontrada");

            if(creditos < consulta.Valor) throw new Exception("Creditos insuficientes.");

            string jsonRequest = JsonConvert.SerializeObject(request.Dados);
            
            try
            {
                var res = await _FireIntegracao.CNPJ(request.Dados.Tipo, RemoverNaoNumericos(request.Dados.NumeroInscricao));
                
                if(string.IsNullOrEmpty(res)) throw new Exception("Consulta sem retorno");

                ConsultaCNPJResultadoDto consultaCNPJResultado 
                    = JsonConvert.DeserializeObject<ConsultaCNPJResultadoDto>(res)
                        ?? new ConsultaCNPJResultadoDto();
                        
                listaDominios = await _dominioRepo.ObterCNPJDominios();

                TratarRetorno(consultaCNPJResultado);

                await _consultaRepo.SalvarConsultaHistorico(
                    request.Dados.UsuarioId, consulta.ConsultaId, request.Dados.NumeroInscricao.ToString(),  jsonRequest, JsonConvert.SerializeObject(consultaCNPJResultado));
                await _usuarioRepo.AtualizaCreditoUsuario(request.Dados.UsuarioId, creditos - consulta.Valor);
                await _usuarioRepo.SalvarConsultaHistorico(request.Dados.UsuarioId, consulta.Valor, (int)TipoOperacaoEnum.Debito);

                Retorno retorno = new(consultaCNPJResultado);
                return retorno;
            

            }
            catch (Exception ex)
            {
                Retorno retorno = new(ex.Message, 999);
                return retorno;
            }
            
        }

        private void TratarRetorno(ConsultaCNPJResultadoDto item)
        {
                item.TipoEstabelecimento = EncontraValorDominio((int)CNPJEnum.TipoEstabelecimento, item.TipoEstabelecimento??"");
                item.Porte = EncontraValorDominio((int)CNPJEnum.PorteEmpresa, item.Porte??"");
                item.SituacaoCadastral.Codigo = EncontraValorDominio((int)CNPJEnum.SituacaoCadastral, item.SituacaoCadastral.Codigo??"");
                foreach (var socio in item.Socios)
                {
                    socio.TipoSocio = EncontraValorDominio((int)CNPJEnum.TipoSocio, socio.TipoSocio??"");
                    socio.Qualificacao = EncontraValorDominio((int)CNPJEnum.QualificacaoSocio, socio.Qualificacao??"");
                    socio.RepresentanteLegal.Qualificacao = EncontraValorDominio((int)CNPJEnum.QualificacaoSocio, socio.RepresentanteLegal.Qualificacao??"");
                }
        }

        private string EncontraValorDominio(int tipo, string codigo)
        {
            return listaDominios.FirstOrDefault(a=>a.Tipo == tipo && a.CodigoCampo == codigo)?.DescricaoCampo ?? codigo;
        }

        private string RemoverNaoNumericos(string input)
        {
            Regex regex = MyRegex();
            return regex.Replace(input, "");
        }

        [GeneratedRegex("[^0-9]")]
        private static partial Regex MyRegex();
    }

}