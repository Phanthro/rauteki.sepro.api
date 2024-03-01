using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rauteki.Fire.Api.Repositories.Model;

[Table("Consulta")]
public class Consulta
{
    [Key]
    [Required]
    public int ConsultaId { get; set; }
    
    [Required]
    public required string Nome { get; set; }

    [Required]
    public required string Descricao { get; set; }

    [Required]
    public decimal Valor { get; set; }

    [Required]
    public required string Link { get; set; }
    public required int? ItemPai { get; set; }

    

}