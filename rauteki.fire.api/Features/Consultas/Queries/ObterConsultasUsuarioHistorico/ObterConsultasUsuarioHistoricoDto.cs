namespace Rauteki.Fire.Api.Features.Consultas.Queries.ObterConsultasUsuarioHistorico;

public class ObterConsultasUsuarioHistoricoDto
{
    public required int ConsultaHistoricoId { get; set; }
    public required int ConsultaId { get; set; }
    
    public required string NomeUsuario { get; set; }
    
    public required string NomeConsulta { get; set; }

    public required string Cpf { get; set; }

    public required string Requisicao { get; set; }
    
    public required string Resposta { get; set; }

    public required DateTime RealizadoEm { get; set; }

}