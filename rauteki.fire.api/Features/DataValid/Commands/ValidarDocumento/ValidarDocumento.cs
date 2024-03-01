using Rauteki.Fire.Api.Features.Helpers;
using MediatR;
using Newtonsoft.Json;
using Rauteki.Fire.Api.Services.Interfaces;
using Rauteki.Fire.Api.Repositories.Interfaces;
using Rauteki.Fire.Api.Misc;

namespace Rauteki.Fire.Api.Features.DataValid.Commands.ValidarDocumento;

public class ValidarDocumento
{

    public record Command(ValidarDocumentoDto Dados) : ICommand<Retorno>;

    public class Handler : ValidarDocumentoDtoValidator, IRequestHandler<Command, Retorno>
    {
        private readonly IFireService _FireService;
        private readonly IClienteRepository _clienteRepo;
        private readonly IConsultaRepository _consultaRepo;

        public Handler(IFireService FireService, IClienteRepository clienteRepo, IConsultaRepository consultaRepo)
        {
            _FireService = FireService;
            _clienteRepo = clienteRepo;
            _consultaRepo = consultaRepo;
        }

        public async Task<Retorno> Handle(Command request, CancellationToken cancellationToken)
        {
            Validate(request);

            decimal creditos = await _clienteRepo.ObterCreditoCliente(request.Dados.ClienteId);
            IEnumerable<Repositories.Model.Consulta> consultas = await _consultaRepo.ObterConsultas();

            var consulta = consultas.Where(x=>x.ConsultaId == (int)ConsultasEnum.DatavalidDocumento).FirstOrDefault();

            if(consulta == null) throw new Exception("Tipo de Consulta não encontrada");

            if(creditos < consulta.Valor) throw new Exception("Creditos insuficientes.");

            string jsonRequest = JsonConvert.SerializeObject(request.Dados);

            try
            {
                string res = await _FireService.DataValidDocumento(jsonRequest);
                
                await _consultaRepo.SalvarConsultaHistorico(request.Dados.UsuarioId, consulta.ConsultaId, request.Dados.Key.CPF,  jsonRequest, res);
                await _clienteRepo.AtualizaCreditoCliente(request.Dados.ClienteId, creditos - consulta.Valor);
                await _clienteRepo.SalvarConsultaHistorico(request.Dados.UsuarioId, request.Dados.ClienteId, consulta.Valor, (int)TipoOperacaoEnum.Debito);

                ValidarDocumentoResultadoDto? validacaoResultado = JsonConvert.DeserializeObject<ValidarDocumentoResultadoDto>(res);

                Retorno retorno = new(validacaoResultado);
                return retorno;
                
            }
            catch (System.Exception ex)
            {
                Retorno retorno = new(ex.Message, 999);
                return retorno;
            }

        }
       

    }
}