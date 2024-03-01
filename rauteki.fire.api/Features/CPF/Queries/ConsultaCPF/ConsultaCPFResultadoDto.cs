using Newtonsoft.Json;

namespace Rauteki.Fire.Api.Features.CPF.Queries.ConsultaCPF;

public class ConsultaCPFResultadoDto
{

    [JsonProperty("ni")]
    public string? Ni { get; set; }

    [JsonProperty("nome")]
    public string? Nome { get; set; }

    [JsonProperty("situacao")]
    public Situacao Situacao { get; set; } = new();

    [JsonProperty("nascimento")]
    public string? Nascimento { get; set; }

    [JsonProperty("obito")]
    public string? Obito { get; set; }

}

public class Situacao
{
    [JsonProperty("codigo")]
    public string? Codigo { get; set; }

    [JsonProperty("descricao")]
    public string? Descricao { get; set; }
}