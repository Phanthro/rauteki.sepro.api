using Newtonsoft.Json;

namespace Rauteki.Fire.Api.Features.DividaAtiva.Queries.ConsultaDividaAtiva;

public class ConsultaDividaAtivaDevedorResultadoDto
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    [JsonProperty("numeroInscricao")]
    public string? NumeroInscricao { get; set; }

    [JsonProperty("numeroProcesso")]
    public string? NumeroProcesso { get; set; }

    [JsonProperty("situacaoInscricao")]
    public string? SituacaoInscricao { get; set; }

    [JsonProperty("situacaoDescricao")]
    public string? SituacaoDescricao { get; set; }

    [JsonProperty("nomeDevedor")]
    public string? NomeDevedor { get; set; }

    [JsonProperty("tipoDevedor")]
    public string? TipoDevedor { get; set; }

    [JsonProperty("valorTotalConsolidadoMoeda")]
    public string? ValorTotalConsolidadoMoeda { get; set; }

    [JsonProperty("cpfCnpj")]
    public string? CpfCnpj { get; set; }

    [JsonProperty("codigoSida")]
    public string? CodigoSida { get; set; }

    [JsonProperty("nomeUnidade")]
    public string? NomeUnidade { get; set; }

    [JsonProperty("codigoComprot")]
    public string? CodigoComprot { get; set; }

    [JsonProperty("codigoUorg")]
    public string? CodigoUorg { get; set; }

}