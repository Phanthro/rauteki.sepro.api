using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rauteki.Fire.Api.Repositories.Model;

//Mudar no futuro para uma classe unica de dominios
public class CCIRDominio
{
    public int Tipo { get; set; }
    public required string DescricaoTipo { get; set; }
    public required string CodigoCampo { get; set; }
    public required string DescricaoCampo { get; set; }

}