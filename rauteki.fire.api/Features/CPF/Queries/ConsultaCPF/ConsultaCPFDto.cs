using System.Text.Json.Serialization;

namespace Rauteki.Fire.Api.Features.CPF.Queries.ConsultaCPF;

public class ConsultaCPFDto
{
    [JsonIgnore]
    public int ClienteId { get; set; }
    [JsonIgnore]
    public int UsuarioId { get; set; }
    public string NumeroInscricao { get; set; } = "";
    
}