
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Queries = Rauteki.Fire.Api.Features.Usuario.Queries;
using Commands = Rauteki.Fire.Api.Features.Usuario.Commands;

namespace rauteki.fire.api.Controllers;


[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;
    private readonly ISender _mediator;

    public UsuarioController(ILogger<UsuarioController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("ListarUsuarios")]
    [Authorize]
    public async Task<IActionResult> ListarUsuarios()
    {
        var clienteId = User.FindFirst("clienteId")?.Value ?? throw new Exception();

        IEnumerable<Queries.ListarUsuarios.ListarUsuariosDto> result =
            await _mediator.Send(new Queries.ListarUsuarios.ListarUsuarios.Query(Convert.ToInt32(clienteId)));

        var retorno = new Retorno(result);

        return Ok(retorno);

    }

    [HttpGet()]
    [Authorize]
    public async Task<IActionResult> Obterusuario(int usuarioId)
    {
        try
        {
            Queries.ObterUsuario.ObterUsuarioDto result =
                await _mediator.Send(new Queries.ObterUsuario.ObterUsuario.Query(usuarioId));

            var retorno = new Retorno(result);

            return Ok(retorno);
        }
        catch (Exception ex)
        {

            var retorno = new Retorno(ex.Message, 500);
            return Ok(retorno);
        }

    }

    [HttpPost()]
    [Authorize]
    public async Task<IActionResult> CriarNovoUsuario([FromBody] Commands.CriarNovoUsuario.CriarNovoUsuarioDto request)
    {
        try
        {
            var clienteId = User.FindFirst("clienteId")?.Value ?? throw new Exception();
            request.ClienteId = Convert.ToInt32(clienteId);

            int result =
                await _mediator.Send(new Commands.CriarNovoUsuario.CriarNovoUsuario.Command(request));

            var retorno = new Retorno(result);

            return Ok(retorno);
        }
        catch (Exception ex)
        {

            var retorno = new Retorno(ex.Message, 500);
            return Ok(retorno);
        }

    }

    [HttpPut()]
    [Authorize]
    public async Task<IActionResult> AlterarUsuario([FromBody] Commands.AlterarUsuario.AlterarUsuarioDto request)
    {
        try {
            int result =
                await _mediator.Send(new Commands.AlterarUsuario.AlterarUsuario.Command(request));

            var retorno = new Retorno(result);

            return Ok(retorno);
        }
        catch (Exception ex)
        {

            var retorno = new Retorno(ex.Message, 500);
            return Ok(retorno);
        }

    }


    [HttpGet("ObterCreditos")]
    [Authorize]
    public async Task<IActionResult> Creditos(int usuarioId)
    {
        
        decimal result = await _mediator.Send(new Queries.ObterCreditosUsuario.ObterCreditosUsuario.Query(usuarioId));

        var retorno = new Retorno(result);

        return Ok(retorno);
    
    }

    [HttpGet("CreditosHistorico")]
    [Authorize]
    public async Task<IActionResult> ObterCreditosHitorico(int usuarioId)
    {
        
        IEnumerable<Queries.ObterCreditosUsuarioHistorico.ObterCreditosUsuarioHistoricoDto> result = 
            await _mediator.Send(new Queries.ObterCreditosUsuarioHistorico.ObterCreditosUsuarioHistorico.Query(usuarioId));

        var retorno = new Retorno(result);
        
        return Ok(retorno);
    
    }
}