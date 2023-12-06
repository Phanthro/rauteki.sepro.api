using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rauteki.Sepro.Api.Repositories.Model;

[Table("Usuario")]
public class Usuario
{
    [Key]
    [Required]
    public int UsuarioId { get; set; }
    [Required]
    public string NumeroInscricao { get; set; } = string.Empty;
    [Required]
    public string Nome { get; set; } = string.Empty;
    [Required]
    public string Sobrenome { get; set; } = string.Empty;
    [Required]
    public string razaoSocial { get; set; } = string.Empty;

}