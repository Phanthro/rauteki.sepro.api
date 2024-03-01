using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rauteki.Fire.Api.Repositories.Model;

[Table("CreditoUsuarioHistorico")]
public class CreditoUsuarioHistorico
{

    [Required]
    public required int UsuarioId { get; set; }

    [Required]
    public required string UsuarioNome { get; set; }
    
    [Required]
    public required decimal Valor { get; set; }

    [Required]
    public required DateTime EfetuadoEm { get; set; }

}