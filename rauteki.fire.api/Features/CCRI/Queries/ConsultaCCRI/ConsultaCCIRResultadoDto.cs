using Newtonsoft.Json;

namespace Rauteki.Fire.Api.Features.CCIR.Queries.ConsultaCCIR;

public class ConsultaCCIRResultadoDto
{
    [JsonProperty("areaCertificada")]
    public float? AreaCertificada { get; set; }

    [JsonProperty("areaMedida")]
    public float? AreaMedida { get; set; }

    [JsonProperty("areaModuloFiscal")]
    public float AreaModuloFiscal { get; set; }

    [JsonProperty("areaModuloRural")]
    public float AreaModuloRural { get; set; }

    [JsonProperty("areaTotal")]
    public float AreaTotal { get; set; }

    [JsonProperty("areasRegistradas")]
    public List<AreasRegistrada> AreasRegistradas { get; set; } = new();

    [JsonProperty("classificacaoFundiaria")]
    public string? ClassificacaoFundiaria { get; set; }

    [JsonProperty("codigoImovelIncra")]
    public string? CodigoImovelIncra { get; set; }

    [JsonProperty("dadosUltimoCcir")]
    public DadosUltimoCcir DadosUltimoCcir { get; set; } = new();

    [JsonProperty("dataProcessamentoUltimaDeclaracao")]
    public string? DataProcessamentoUltimaDeclaracao { get; set; }

    [JsonProperty("denominacao")]
    public string? Denominacao { get; set; }

    [JsonProperty("fracaoMinimaParcelamento")]
    public float FracaoMinimaParcelamento { get; set; }

    [JsonProperty("indicacoesLocalizacao")]
    public string? IndicacoesLocalizacao { get; set; }

    [JsonProperty("municipioSede")]
    public string? MunicipioSede { get; set; }

    [JsonProperty("numeroModulosFiscais")]
    public float NumeroModulosFiscais { get; set; }

    [JsonProperty("numeroModulosRurais")]
    public float NumeroModulosRurais { get; set; }

    [JsonProperty("titulares")]
    public List<Titulare> Titulares { get; set; } = new();

    [JsonProperty("totalAreaPosseJustoTitulo")]
    public float? TotalAreaPosseJustoTitulo { get; set; }

    [JsonProperty("totalAreaPosseSimplesOcupacao")]
    public float? TotalAreaPosseSimplesOcupacao { get; set; }

    [JsonProperty("totalAreaRegistrada")]
    public float? TotalAreaRegistrada { get; set; }

    [JsonProperty("totalPessoasRelacionadasImovel")]
    public int? TotalPessoasRelacionadasImovel { get; set; }

    [JsonProperty("ufSede")]
    public string? UfSede { get; set; }

}
public class AreasRegistrada
{
    [JsonProperty("area")]
    public float? Area { get; set; }

    [JsonProperty("cnsOuOficio")]
    public string? CnsOuOficio { get; set; }

    [JsonProperty("dataRegistro")]
    public string? DataRegistro { get; set; }

    [JsonProperty("livroOuFicha")]
    public string? LivroOuFicha { get; set; }

    [JsonProperty("matriculaOuTranscricao")]
    public string? MatriculaOuTranscricao { get; set; }

    [JsonProperty("municipioCartorio")]
    public string? MunicipioCartorio { get; set; }

    [JsonProperty("registro")]
    public string? Registro { get; set; }

    [JsonProperty("ufCartorio")]
    public string? UfCartorio { get; set; }
}

public class DadosUltimoCcir
{
    [JsonProperty("dataGeracaoCcir")]
    public string? DataGeracaoCcir { get; set; }

    [JsonProperty("dataLancamento")]
    public string? DataLancamento { get; set; }

    [JsonProperty("dataVencimentoCcir")]
    public string? DataVencimentoCcir { get; set; }

    [JsonProperty("debitosAnteriores")]
    public float? DebitosAnteriores { get; set; }

    [JsonProperty("juros")]
    public float? Juros { get; set; }

    [JsonProperty("multa")]
    public float? Multa { get; set; }

    [JsonProperty("numeroAutenticidadeCcir")]
    public string? NumeroAutenticidadeCcir { get; set; }

    [JsonProperty("numeroCcir")]
    public string? NumeroCcir { get; set; }

    [JsonProperty("situacaoCcir")]
    public string? SituacaoCcir { get; set; }

    [JsonProperty("taxaServicosCadastrais")]
    public float? TaxaServicosCadastrais { get; set; }

    [JsonProperty("valorCobrado")]
    public float? ValorCobrado { get; set; }

    [JsonProperty("valorTotal")]
    public float? ValorTotal { get; set; }
}

public class Titulare
{
    [JsonProperty("condicaoTitularidade")]
    public string? CondicaoTitularidade { get; set; }

    [JsonProperty("cpfCnpj")]
    public string? CpfCnpj { get; set; }

    [JsonProperty("declarante")]
    public string? Declarante { get; set; }

    [JsonProperty("nacionalidade")]
    public string? Nacionalidade { get; set; }

    [JsonProperty("nomeTitular")]
    public string? NomeTitular { get; set; }

    [JsonProperty("percentualDetencao")]
    public float PercentualDetencao { get; set; }
}