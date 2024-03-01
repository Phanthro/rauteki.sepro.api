using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Rauteki.Fire.Api.Features.DataValid.Commands.ValidarDocumento;

public class ValidarDocumentoResultadoDto
{
    [JsonProperty("documento")]
    [JsonPropertyName("documento")]
    public string Documento { get; set; } = "";
    
    [JsonProperty("cnh")]
    [JsonPropertyName("cnh")]
    public CnhResposta CNH { get; set; } = new();


    [JsonProperty("biometria_face")]
    [JsonPropertyName("biometria_face")]
    public BiometriaFaceResposta BiometriaFace { get; set; } = new();
}


public class CnhResposta
{
    [JsonProperty("nome")]
    [JsonPropertyName("nome")]
    public bool Nome { get; set; }

    [JsonProperty("nome_ocr")]
    [JsonPropertyName("nome_ocr")]
    public string NomeOcr { get; set; } = "";

    [JsonProperty("nome_similaridade")]
    [JsonPropertyName("nome_similaridade")]
    public double NomeSimilaridade { get; set; }


    [JsonProperty("numero_registro")]
    [JsonPropertyName("numero_registro")]
    public bool NumeroRegistro { get; set; }

    [JsonProperty("numero_registro_ocr")]
    [JsonPropertyName("numero_registro_ocr")]
    public string NumeroRegistroOcr { get; set; } = "";


    [JsonProperty("identidade")]
    [JsonPropertyName("identidade")]
    public bool Identidade { get; set; }

    [JsonProperty("identidade_similaridade")]
    [JsonPropertyName("identidade_similaridade")]
    public double IdentidadeSimilaridade { get; set; }

    [JsonProperty("identidade_ocr")]
    [JsonPropertyName("identidade_ocr")]
    public string IdentidadeOCR { get; set; } = "";

    [JsonProperty("data_nascimento")]
    [JsonPropertyName("data_nascimento")]
    public bool DataNascimento { get; set; }

    
    [JsonProperty("data_nascimento_ocr")]
    [JsonPropertyName("data_nascimento_ocr")]
    public string DataNascimentoOCR { get; set; } = "";
    

    [JsonProperty("data_primeira_habilitacao")]
    [JsonPropertyName("data_primeira_habilitacao")]
    public bool DataPrimeiraHabilitacao { get; set; }

    
    [JsonProperty("data_primeira_habilitacao_ocr")]
    [JsonPropertyName("data_primeira_habilitacao_ocr")]
    public string DataPrimeiraHabilitacaoOCR { get; set; } = "";


    [JsonProperty("data_ultima_emissao")]
    [JsonPropertyName("data_ultima_emissao")]
    public bool DataUltimaEmissao { get; set; }

    [JsonProperty("data_ultima_emissao_ocr")]
    [JsonPropertyName("data_ultima_emissao_ocr")]
    public string DataUltimaEmissaoOCR { get; set; } = "";


    [JsonProperty("data_validade")]
    [JsonPropertyName("data_validade")]
    public bool DataValidade { get; set; }

    [JsonProperty("data_validade_ocr")]
    [JsonPropertyName("data_validade_ocr")]
    public string DataValidadeOCR { get; set; } = "";

    [JsonProperty("retrato")]
    [JsonPropertyName("retrato")]
    public BiometriaFaceResposta Retrato { get; set; } = new();
    
}

public class BiometriaFaceResposta
{
    [JsonProperty("disponivel")]
    [JsonPropertyName("disponivel")]
    public bool Disponivel { get; set; }

    [JsonProperty("probabilidade")]
    [JsonPropertyName("probabilidade")]
    public string Probabilidade { get; set; } = "";

    [JsonProperty("similaridade")]
    [JsonPropertyName("similaridade")]
    public double Similaridade { get; set; }
}

