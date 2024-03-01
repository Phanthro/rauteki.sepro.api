using System.Text.Json.Serialization;

namespace Rauteki.Fire.Api.Features.CND.Commands.ConsultaCND;

public class ConsultaCNDDto
{
    [JsonIgnore]
    public int ClienteId { get; set; }
    [JsonIgnore]
    public int UsuarioId { get; set; }
    public int TipoContribuinte { get; set; }
    public string ContribuinteConsulta { get; set; } = "";
    public int CodigoIdentificacao { get; set; }
    public bool GerarCertidaoPdf { get; set; }
    
}