using Newtonsoft.Json;

namespace Rauteki.Fire.Api.Features.DividaAtiva.Queries.ConsultaDividaAtiva;

public class ConsultaDividaAtivaInscricaoResultadoDto
{
    [JsonProperty("inscricao")]
    public string? Inscricao { get; set; }

    [JsonProperty("processoAdministrativo")]
    public string? ProcessoAdministrativo { get; set; }

    [JsonProperty("situacao")]
    public string? Situacao { get; set; }

    [JsonProperty("dataInscricao")]
    public string? DataInscricao { get; set; }

    [JsonProperty("numeroPFNResponsavel")]
    public string? NumeroPFNResponsavel { get; set; }

    [JsonProperty("nomePFNResponsavel")]
    public string? NomePFNResponsavel { get; set; }

    [JsonProperty("numeroPFNInscricao")]
    public string? NumeroPFNInscricao { get; set; }

    [JsonProperty("nomePFNInscricao")]
    public string? NomePFNInscricao { get; set; }

    [JsonProperty("numeroProcessoJudicial")]
    public string? NumeroProcessoJudicial { get; set; }

    [JsonProperty("numeroProcessoJudicialNovo")]
    public string? NumeroProcessoJudicialNovo { get; set; }

    [JsonProperty("orgaoOrigem")]
    public string? OrgaoOrigem { get; set; }

    [JsonProperty("codigoNaturezaReceita")]
    public string? CodigoNaturezaReceita { get; set; }

    [JsonProperty("nomeNaturezaReceita")]
    public string? NomeNaturezaReceita { get; set; }

    [JsonProperty("codigoReceitaPrincipal")]
    public string? CodigoReceitaPrincipal { get; set; }

    [JsonProperty("nomeReceita")]
    public string? NomeReceita { get; set; }

    [JsonProperty("codigoSerie")]
    public string? CodigoSerie { get; set; }

    [JsonProperty("nomeSerie")]
    public string? NomeSerie { get; set; }

    [JsonProperty("codigoOrgaoJustica")]
    public string? CodigoOrgaoJustica { get; set; }

    [JsonProperty("nomeOrgaoJustica")]
    public string? NomeOrgaoJustica { get; set; }

    [JsonProperty("numeroJuizo")]
    public string? NumeroJuizo { get; set; }

    [JsonProperty("descricaoJuizo")]
    public string? DescricaoJuizo { get; set; }

    [JsonProperty("dataProtocoloJudExecucao")]
    public string? DataProtocoloJudExecucao { get; set; }

    [JsonProperty("dataDistribuicaoJudicial")]
    public string? DataDistribuicaoJudicial { get; set; }

    [JsonProperty("indicadorMoedaTotalInscrito")]
    public string? IndicadorMoedaTotalInscrito { get; set; }

    [JsonProperty("valorTotalInscritoMoeda")]
    public string? ValorTotalInscritoMoeda { get; set; }

    [JsonProperty("valorTotalInscritoIndex")]
    public string? ValorTotalInscritoIndex { get; set; }

    [JsonProperty("indicadorMoedaTotalConsolidado")]
    public string? IndicadorMoedaTotalConsolidado { get; set; }

    [JsonProperty("valorTotalConsolidadoMoeda")]
    public string? ValorTotalConsolidadoMoeda { get; set; }

    [JsonProperty("indicadorMoedaTotalRemanescente")]
    public string? IndicadorMoedaTotalRemanescente { get; set; }

    [JsonProperty("valorRemanescenteMoeda")]
    public string? ValorRemanescenteMoeda { get; set; }

    [JsonProperty("valorRemanescenteIndex")]
    public string? ValorRemanescenteIndex { get; set; }

    [JsonProperty("dataDevolucaoProcesso")]
    public string? DataDevolucaoProcesso { get; set; }

    [JsonProperty("numeroAutoInfracao")]
    public string? NumeroAutoInfracao { get; set; }

    [JsonProperty("indicadorPrescricaoSV8")]
    public string? IndicadorPrescricaoSV8 { get; set; }

    [JsonProperty("dataDecretacaoFalencia")]
    public string? DataDecretacaoFalencia { get; set; }

    [JsonProperty("dataFimProcurador")]
    public string? DataFimProcurador { get; set; }

    [JsonProperty("numeroImovelITR")]
    public string? NumeroImovelITR { get; set; }

    [JsonProperty("dataExtincaoInscricao")]
    public string? DataExtincaoInscricao { get; set; }

    [JsonProperty("motivoSuspensaoExigibilidade")]
    public string? MotivoSuspensaoExigibilidade { get; set; }

    [JsonProperty("numeroRipSpu")]
    public string? NumeroRipSpu { get; set; }

    [JsonProperty("indicadorAnaliseOrgaoOrigem")]
    public string? IndicadorAnaliseOrgaoOrigem { get; set; }

    [JsonProperty("motivoExtincaoInscricao")]
    public string? MotivoExtincaoInscricao { get; set; }

    [JsonProperty("indicadorProtImpedAjuiz")]
    public string? IndicadorProtImpedAjuiz { get; set; }

    [JsonProperty("numeroAgrupamento")]
    public string? NumeroAgrupamento { get; set; }

    [JsonProperty("numeroInscricaoOriginal")]
    public string? NumeroInscricaoOriginal { get; set; }

    [JsonProperty("numeroInscricaoDerivada1")]
    public string? NumeroInscricaoDerivada1 { get; set; }

    [JsonProperty("numeroInscricaoDerivada2")]
    public string? NumeroInscricaoDerivada2 { get; set; }

    [JsonProperty("numeroInscricaoDerivada3")]
    public string? NumeroInscricaoDerivada3 { get; set; }

    [JsonProperty("numeroInscricaoDerivada4")]
    public string? NumeroInscricaoDerivada4 { get; set; }

    [JsonProperty("numeroInscricaoDerivada5")]
    public string? NumeroInscricaoDerivada5 { get; set; }

    [JsonProperty("numeroInscricaoDerivada6")]
    public string? NumeroInscricaoDerivada6 { get; set; }

    [JsonProperty("numeroInscricaoDerivada7")]
    public string? NumeroInscricaoDerivada7 { get; set; }

    [JsonProperty("dcomp")]
    public string? Dcomp { get; set; }

    [JsonProperty("descricaoNaoCalculado")]
    public string? DescricaoNaoCalculado { get; set; }

    [JsonProperty("codigoMunicipioSPU")]
    public int CodigoMunicipioSPU { get; set; }

    [JsonProperty("codigoSistemaOrigem")]
    public string? CodigoSistemaOrigem { get; set; }

    [JsonProperty("descricaoSistemaOrigem")]
    public string? DescricaoSistemaOrigem { get; set; }

}