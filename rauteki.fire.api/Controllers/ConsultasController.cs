using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Queries = Rauteki.Fire.Api.Features.Consultas.Queries;

namespace Rauteki.Fire.Api.Controllers;

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

    [HttpGet("ObterConsultas")]
    [AllowAnonymous]
    public async Task<IActionResult> ObterConsultas()
    {

        IEnumerable<Queries.ObterConsultas.ObterConsultasDto> result = await _mediator.Send(new Queries.ObterConsultas.ObterConsultas.Query());
        var retorno = new Retorno(result);
        return Ok(retorno);

    }

    [HttpGet("UsuarioConsultasHistorico")]
    [Authorize]
    public async Task<IActionResult> ObterCreditosClienteHitorico(int usuarioId, int consultaHistoricoId)
    {
        
        IEnumerable<Queries.ObterConsultasUsuarioHistorico.ObterConsultasUsuarioHistoricoDto> result = 
            await _mediator.Send(new Queries.ObterConsultasUsuarioHistorico.ObterConsultasUsuarioHistorico.Query(usuarioId, consultaHistoricoId));

        var retorno = new Retorno(result);
        
        return Ok(retorno);
    
    }



}

