using Rauteki.Sepro.Api.Misc.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Commands = Rauteki.Sepro.Api.Features.DataValid.Commands.ValidarIdentidadeFacial;

namespace Rauteki.Sepro.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public class ConsultasController : ControllerBase
{
    private readonly ILogger<ConsultasController> _logger;
    private readonly ISender _mediator;
    public ConsultasController(ILogger<ConsultasController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost("ValidarIdentidade/facial")]
    [Authorize]
    public async Task<IActionResult> CriarNovoClienteAsync([FromBody]Commands.ValidarIdentidadeFacialDto request)
    {
        
        Commands.ValidarIdentidadeFacialResultadoDto result = await _mediator.Send(new Commands.ValidarIdentidadeFacial.Command(request));
        var retorno = new Retorno(result);
        return Ok(retorno);
    
    }


}

