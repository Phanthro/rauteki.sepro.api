using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Commands = Rauteki.Fire.Api.Features.CND.Commands;
using Rauteki.Fire.Api.Misc;

namespace Rauteki.Fire.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public class CNDController : ControllerBase
{
    private readonly ILogger<CNDController> _logger;
    private readonly ISender _mediator;
    public CNDController(ILogger<CNDController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost()]
    [Authorize]
    public async Task<IActionResult> ConsultaCND([FromBody] Commands.ConsultaCND.ConsultaCNDDto request)
    {
        var usuarioId = User.FindFirst("usuarioId")?.Value ?? throw new Exception("Identificação do usuário não encontrado");
        var clienteId = User.FindFirst("clienteId")?.Value ?? throw new Exception("Identificação do cliente não encontrado");
        request.ClienteId = Convert.ToInt32(clienteId);
        request.UsuarioId = Convert.ToInt32(usuarioId);
        
        
        Retorno retorno = 
            await _mediator.Send(new Commands.ConsultaCND.ConsultaCND.Query(request));

        if(retorno.Status != 200)
        {
            return BadRequest(retorno);
        }

        return Ok(retorno);
    
    }



}

