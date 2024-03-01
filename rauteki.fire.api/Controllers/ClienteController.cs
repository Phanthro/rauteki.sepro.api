using Rauteki.Fire.Api.Misc.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Queries = Rauteki.Fire.Api.Features.Cliente.Queries;

namespace Rauteki.Fire.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public class ClienteController : ControllerBase
{

    private readonly ILogger<ConsultasController> _logger;
    private readonly ISender _mediator;
    public ClienteController(ILogger<ConsultasController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("CreditosCliente")]
    [Authorize]
    public async Task<IActionResult> CreditosCliente(int clienteId)
    {
        
        decimal result = await _mediator.Send(new Queries.ObterCreditosCliente.ObterCreditosCliente.Query(clienteId));

        var retorno = new Retorno(result);

        return Ok(retorno);
    
    }

    [HttpGet("CreditosClienteHistorico")]
    [Authorize]
    public async Task<IActionResult> ObterCreditosClienteHitorico(int clienteId)
    {
        
        IEnumerable<Queries.ObterCreditosClienteHistorico.ObterCreditosClienteHistoricoDto> result = 
            await _mediator.Send(new Queries.ObterCreditosClienteHistorico.ObterCreditosClienteHistorico.Query(clienteId));

        var retorno = new Retorno(result);
        
        return Ok(retorno);
    
    }

}