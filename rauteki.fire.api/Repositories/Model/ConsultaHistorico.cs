using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rauteki.Fire.Api.Repositories.Model;

[Table("Consulta")]
public class ConsultaHistorico
{
    [Required]
    public required int ConsultaHistoricoId { get; set; }
    [Required]
    public required int ConsultaId { get; set; }
    
    [Required]
    public required string NomeUsuario { get; set; }
    
    [Required]
    public required string NomeConsulta { get; set; }

    [Required]
    public required string Cpf { get; set; }

    [Required]
    public required string Requisicao { get; set; }
    
    [Required]
    public required string Resposta { get; set; }

    [Required]
    public required DateTime RealizadoEm { get; set; }

    

}