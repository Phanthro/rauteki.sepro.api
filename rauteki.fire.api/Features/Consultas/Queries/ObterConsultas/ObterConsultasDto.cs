namespace Rauteki.Fire.Api.Features.Consultas.Queries.ObterConsultas;

public class ObterConsultasDto
{
    public int ConsultaId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Valor { get; set; }
    public string? Link { get; set; }
    public int? ItemPai { get; set; }
    
}