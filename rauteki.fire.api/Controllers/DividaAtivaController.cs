using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Queries = Rauteki.Fire.Api.Features.DividaAtiva.Queries;
using Rauteki.Fire.Api.Misc;

namespace Rauteki.Fire.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public class DividaAtivaController : ControllerBase
{
    private readonly ILogger<DividaAtivaController> _logger;
    private readonly ISender _mediator;
    public DividaAtivaController(ILogger<DividaAtivaController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost()]
    [Authorize]
    public async Task<IActionResult> DividaAtiva([FromBody] Queries.ConsultaDividaAtiva.ConsultaDividaAtivaDto request)
    {
        try
        {
            var usuarioId = User.FindFirst("usuarioId")?.Value ?? throw new Exception("Identificação do usuário não encontrado");
            var clienteId = User.FindFirst("clienteId")?.Value ?? throw new Exception("Identificação do cliente não encontrado");
            request.ClienteId = Convert.ToInt32(clienteId);
            request.UsuarioId = Convert.ToInt32(usuarioId);
            
            
            Retorno retorno = 
                await _mediator.Send(new Queries.ConsultaDividaAtiva.ConsultaDividaAtiva.Query(request));

            if(retorno.Status != 200)
            {
                return BadRequest(retorno);
            }

            return Ok(retorno);

        }
        catch (Exception ex)
        {
            
            var retorno = new Retorno(ex.Message, 500);
            return Ok(retorno);
        }
        
    }



}

