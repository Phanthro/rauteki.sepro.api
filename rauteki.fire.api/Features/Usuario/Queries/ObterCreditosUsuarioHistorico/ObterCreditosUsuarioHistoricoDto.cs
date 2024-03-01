namespace Rauteki.Fire.Api.Features.Usuario.Queries.ObterCreditosUsuarioHistorico;

public class ObterCreditosUsuarioHistoricoDto
{
    public required int UsuarioId { get; set; }

    public required string UsuarioNome { get; set; }
    
    public required decimal Valor { get; set; }

    public required DateTime EfetuadoEm { get; set; }
    
}