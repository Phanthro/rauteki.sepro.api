using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Queries = Rauteki.Fire.Api.Features.CPF.Queries;
using Rauteki.Fire.Api.Misc;

namespace Rauteki.Fire.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public class CPFController : ControllerBase
{
    private readonly ILogger<CPFController> _logger;
    private readonly ISender _mediator;
    public CPFController(ILogger<CPFController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost()]
    [Authorize]
    public async Task<IActionResult> ConsultaCPF([FromBody] Queries.ConsultaCPF.ConsultaCPFDto request)
    {
        var usuarioId = User.FindFirst("usuarioId")?.Value ?? throw new Exception("Identificação do usuário não encontrado");
        var clienteId = User.FindFirst("clienteId")?.Value ?? throw new Exception("Identificação do cliente não encontrado");
        request.ClienteId = Convert.ToInt32(clienteId);
        request.UsuarioId = Convert.ToInt32(usuarioId);
        
        
        Retorno retorno = 
            await _mediator.Send(new Queries.ConsultaCPF.ConsultaCPF.Query(request));

        if(retorno.Status != 200)
        {
            return BadRequest(retorno);
        }

        return Ok(retorno);
    
    }



}

