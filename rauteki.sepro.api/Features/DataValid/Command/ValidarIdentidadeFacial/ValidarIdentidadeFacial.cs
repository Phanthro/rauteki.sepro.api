using Rauteki.Sepro.Api.Features.Helpers;
using MediatR;
using Newtonsoft.Json;
using Rauteki.Sepro.Api.Services.Interfaces;

namespace Rauteki.Sepro.Api.Features.DataValid.Commands.ValidarIdentidadeFacial;

public class ValidarIdentidadeFacial
{

    public record Command(ValidarIdentidadeFacialDto Dados) : ICommand<ValidarIdentidadeFacialResultadoDto?>;

    public class Handler : ValidarIdentidadeFacialDtoValidator, IRequestHandler<Command, ValidarIdentidadeFacialResultadoDto?>
    {
        private readonly ISerproService _serproService;

        public Handler(ISerproService serproService)
        {
            _serproService = serproService;
        }

        public async Task<ValidarIdentidadeFacialResultadoDto?> Handle(Command request, CancellationToken cancellationToken)
        {
            Validate(request);

            string jsonRequest = JsonConvert.SerializeObject(request.Dados);
            string res = await _serproService.DataValidFacial(jsonRequest);

            ValidarIdentidadeFacialResultadoDto? validacaoResultado = JsonConvert.DeserializeObject<ValidarIdentidadeFacialResultadoDto>(res);

            return validacaoResultado;

        }
       

    }
}