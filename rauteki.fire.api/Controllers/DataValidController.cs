using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Commands = Rauteki.Fire.Api.Features.DataValid.Commands;
using Queries = Rauteki.Fire.Api.Features.Consultas.Queries;
using Rauteki.Fire.Api.Misc;

namespace Rauteki.Fire.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public class DataValidController : ControllerBase
{
    private readonly ILogger<DataValidController> _logger;
    private readonly ISender _mediator;
    public DataValidController(ILogger<DataValidController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost("ValidarIdentidade/facial")]
    [Authorize]
    [TypeFilter(typeof(CustomExceptionFilter))]
    public async Task<IActionResult> ValidarIdentidadeFacial([FromBody] Commands.ValidarIdentidadeFacial.ValidarIdentidadeFacialDto request)
    {

    
        var usuarioId = User.FindFirst("usuarioId")?.Value ?? throw new Exception("Identificação do usuário não encontrado");
        var clienteId = User.FindFirst("clienteId")?.Value ?? throw new Exception("Identificação do cliente não encontrado");
        request.ClienteId = Convert.ToInt32(clienteId);
        request.UsuarioId = Convert.ToInt32(usuarioId);

        Retorno retorno = await _mediator.Send(new Commands.ValidarIdentidadeFacial.ValidarIdentidadeFacial.Command(request));
        
        if(retorno.Status != 200)
        {
            return BadRequest(retorno);
        }

        return Ok(retorno);
    

    }

    [HttpPost("ValidarIdentidade/documento")]
    [Authorize]
    [TypeFilter(typeof(CustomExceptionFilter))]
    public async Task<IActionResult> ValidarDocumento([FromBody] Commands.ValidarDocumento.ValidarDocumentoDto request)
    {

        try
        {
            var usuarioId = User.FindFirst("usuarioId")?.Value ?? throw new Exception("Identificação do usuário não encontrado");
            var clienteId = User.FindFirst("clienteId")?.Value ?? throw new Exception("Identificação do cliente não encontrado");
            request.ClienteId = Convert.ToInt32(clienteId);
            request.UsuarioId = Convert.ToInt32(usuarioId);

            Retorno retorno = await _mediator.Send(new Commands.ValidarDocumento.ValidarDocumento.Command(request));
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

