using System.Text.Json.Serialization;

namespace Rauteki.Fire.Api.Features.CNPJ.Queries.ConsultaCNPJ;

public class ConsultaCNPJDto
{
    [JsonIgnore]
    public int ClienteId { get; set; }
    [JsonIgnore]
    public int UsuarioId { get; set; }
    public string Tipo { get; set; } = "";
    public string NumeroInscricao { get; set; } = "";
    
}