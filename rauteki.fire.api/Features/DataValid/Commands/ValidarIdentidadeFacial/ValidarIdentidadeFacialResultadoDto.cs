using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Rauteki.Fire.Api.Features.DataValid.Commands.ValidarIdentidadeFacial;

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

public class CnhResposta
{
    [JsonProperty("nome")]
    [JsonPropertyName("nome")]
    public bool Nome { get; set; }

    [JsonProperty("nome_similaridade")]
    [JsonPropertyName("nome_similaridade")]
    public double NomeSimilaridade { get; set; }

    [JsonProperty("numero_registro")]
    [JsonPropertyName("numero_registro")]
    public bool NumeroRegistro { get; set; }

    [JsonProperty("categoria")]
    [JsonPropertyName("categoria")]
    public bool Categoria { get; set; }

    [JsonProperty("codigo_situacao")]
    [JsonPropertyName("codigo_situacao")]
    public bool CodigoSituacao { get; set; }

    [JsonProperty("data_ultima_emissao")]
    [JsonPropertyName("data_ultima_emissao")]
    public bool DataUltimaEmissao { get; set; }

    [JsonProperty("data_primeira_habilitacao")]
    [JsonPropertyName("data_primeira_habilitacao")]
    public bool DataPrimeiraHabilitacao { get; set; }

    [JsonProperty("data_validade")]
    [JsonPropertyName("data_validade")]
    public bool DataValidade { get; set; }

    [JsonProperty("possui_impedimento")]
    [JsonPropertyName("possui_impedimento")]
    public bool PossuiImpedimento { get; set; }

    [JsonProperty("observacoes")]
    [JsonPropertyName("observacoes")]
    public bool Observacoes { get; set; }

    [JsonProperty("observacoes_similaridade")]
    [JsonPropertyName("observacoes_similaridade")]
    public double ObservacoesSimilaridade { get; set; }
}

public class DocumentoResposta
{
    [JsonProperty("tipo")]
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    [JsonProperty("numero")]
    [JsonPropertyName("numero")]
    public bool Numero { get; set; }

    [JsonProperty("numero_similaridade")]
    [JsonPropertyName("numero_similaridade")]
    public double NumeroSimilaridade { get; set; }

    [JsonProperty("orgao_expedidor")]
    [JsonPropertyName("orgao_expedidor")]
    public bool OrgaoExpedidor { get; set; }

    [JsonProperty("uf_expedidor")]
    [JsonPropertyName("uf_expedidor")]
    public bool UFExpedidor { get; set; }
}

public class EnderecoResposta
{
    [JsonProperty("logradouro")]
    [JsonPropertyName("logradouro")]
    public bool Logradouro { get; set; }

    [JsonProperty("logradouro_similaridade")]
    [JsonPropertyName("logradouro_similaridade")]
    public double LogradouroSimilaridade { get; set; }

    [JsonProperty("numero")]
    [JsonPropertyName("numero")]
    public bool Numero { get; set; }

    [JsonProperty("numero_similaridade")]
    [JsonPropertyName("numero_similaridade")]
    public double NumeroSimilaridade { get; set; }

    [JsonProperty("bairro")]
    [JsonPropertyName("bairro")]
    public bool Bairro { get; set; }

    [JsonProperty("bairro_similaridade")]
    [JsonPropertyName("bairro_similaridade")]
    public double BairroSimilaridade { get; set; }

    [JsonProperty("cep")]
    [JsonPropertyName("cep")]
    public bool CEP { get; set; }

    [JsonProperty("municipio")]
    [JsonPropertyName("municipio")]
    public bool Municipio { get; set; }

    [JsonProperty("municipio_similaridade")]
    [JsonPropertyName("municipio_similaridade")]
    public double MunicipioSimilaridade { get; set; }

    [JsonProperty("uf")]
    [JsonPropertyName("uf")]
    public bool UF { get; set; }
}

public class FiliacaoResposta
{
    [JsonProperty("nome_mae")]
    [JsonPropertyName("nome_mae")]
    public bool NomeMae { get; set; }

    [JsonProperty("nome_mae_similaridade")]
    [JsonPropertyName("nome_mae_similaridade")]
    public double NomeMaeSimilaridade { get; set; }

    [JsonProperty("nome_pai")]
    [JsonPropertyName("nome_pai")]
    public bool NomePai { get; set; }

    [JsonProperty("nome_pai_similaridade")]
    [JsonPropertyName("nome_pai_similaridade")]
    public double NomePaiSimilaridade { get; set; }
}

public class ValidarIdentidadeFacialResultadoDto
{
    [JsonProperty("cpf_disponivel")]
    [JsonPropertyName("cpf_disponivel")]
    public bool CPFDisponivel { get; set; }

    [JsonProperty("nome")]
    [JsonPropertyName("nome")]
    public bool Nome { get; set; }

    [JsonProperty("nome_similaridade")]
    [JsonPropertyName("nome_similaridade")]
    public double NomeSimilaridade { get; set; }

    [JsonProperty("data_nascimento")]
    [JsonPropertyName("data_nascimento")]
    public bool DataNascimento { get; set; }

    [JsonProperty("situacao_cpf")]
    [JsonPropertyName("situacao_cpf")]
    public bool SituacaoCPF { get; set; }

    [JsonProperty("sexo")]
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    [JsonProperty("nacionalidade")]
    [JsonPropertyName("nacionalidade")]
    public bool Nacionalidade { get; set; }

    [JsonProperty("cnh_disponivel")]
    [JsonPropertyName("cnh_disponivel")]
    public bool CNHDisponivel { get; set; }

    [JsonProperty("cnh")]
    [JsonPropertyName("cnh")]
    public CnhResposta CNH { get; set; } = new();

    [JsonProperty("filiacao")]
    [JsonPropertyName("filiacao")]
    public FiliacaoResposta Filiacao { get; set; } = new();

    [JsonProperty("documento")]
    [JsonPropertyName("documento")]
    public DocumentoResposta Documento { get; set; } = new();

    [JsonProperty("endereco")]
    [JsonPropertyName("endereco")]
    public EnderecoResposta Endereco { get; set; } = new();

    [JsonProperty("biometria_face")]
    [JsonPropertyName("biometria_face")]
    public BiometriaFaceResposta BiometriaFace { get; set; } = new();
}
