namespace Rauteki.Fire.Api.Features.Cliente.Queries.ObterCreditosClienteHistorico;

public class ObterCreditosClienteHistoricoDto
{
    public required int ClienteId { get; set; }

    public required string ClienteNome { get; set; }

    public required int UsuarioId { get; set; }

    public required string UsuarioNome { get; set; }
    
    public required decimal Valor { get; set; }

    public required DateTime EfetuadoEm { get; set; }
    
}