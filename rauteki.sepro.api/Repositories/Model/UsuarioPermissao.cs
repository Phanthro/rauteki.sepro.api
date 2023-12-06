using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rauteki.Sepro.Api.Repositories.Model;

[Table("UsuarioPermissaoPagina")]
public class UsuarioPermissaoPagina
{
    [Key]
    [Required]
    public int UsuarioId { get; set; }
    [Key]
    [Required]
    public int PaginaId { get; set; }
    

}