using Rauteki.Fire.Api.Features.Helpers;
using MediatR;
using Newtonsoft.Json;
using Rauteki.Fire.Api.Services.Interfaces;
using Rauteki.Fire.Api.Repositories.Interfaces;
using Rauteki.Fire.Api.Misc;

namespace Rauteki.Fire.Api.Features.DataValid.Commands.ValidarIdentidadeFacial;

public class ValidarIdentidadeFacial
{

    public record Command(ValidarIdentidadeFacialDto Dados) : ICommand<Retorno>;

    public class Handler : ValidarIdentidadeFacialDtoValidator, IRequestHandler<Command, Retorno>
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

        public async Task<Retorno> Handle(Command request, CancellationToken cancellationToken)
        {
            Validate(request);

            decimal creditos = await _usuarioRepo.ObterCreditoUsuario(request.Dados.UsuarioId);
            IEnumerable<Repositories.Model.Consulta> consultas = await _consultaRepo.ObterConsultas();

            var consulta = 
                consultas.Where(x=>x.ConsultaId == (int)ConsultasEnum.DatavalidFacial)
                .FirstOrDefault() 
                ?? throw new Exception("Tipo de Consulta não encontrada");

            if(creditos < consulta.Valor) 
                throw new Exception("Creditos insuficientes.");

            string jsonRequest = JsonConvert.SerializeObject(request.Dados);

            string res = await _FireIntegracao.DataValidFacial(jsonRequest);
            
            await _consultaRepo.SalvarConsultaHistorico(request.Dados.UsuarioId, consulta.ConsultaId, request.Dados.Key.CPF,  jsonRequest, res);
            await _usuarioRepo.AtualizaCreditoUsuario(request.Dados.UsuarioId, creditos - consulta.Valor);
            await _usuarioRepo.SalvarConsultaHistorico(request.Dados.UsuarioId, consulta.Valor, (int)TipoOperacaoEnum.Debito);

            ValidarIdentidadeFacialResultadoDto? validacaoResultado = JsonConvert.DeserializeObject<ValidarIdentidadeFacialResultadoDto>(res);

            Retorno retorno = new(validacaoResultado);
            return retorno;
            
        

        }
       

    }
}