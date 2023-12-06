using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Rauteki.Sepro.Api.Features.DataValid.Commands.ValidarIdentidadeFacial;

public class ValidarIdentidadeFacialDto
{
    [JsonProperty("key")]
    [JsonPropertyName("key")]
    public required Key Key { get; set; }

    [JsonProperty("answer")]
    [JsonPropertyName("answer")]
    public required Answer Answer { get; set; }
}

public class Answer
{
    [JsonProperty("nome")]
    [JsonPropertyName("nome")]
    public required string Nome { get; set; }

    [JsonProperty("sexo")]
    [JsonPropertyName("sexo")]
    public required string Sexo { get; set; }

    [JsonProperty("nacionalidade")]
    [JsonPropertyName("nacionalidade")]
    public required string Nacionalidade { get; set; }

    [JsonProperty("data_nascimento")]
    [JsonPropertyName("data_nascimento")]
    public required string Data_nascimento { get; set; }

    [JsonProperty("situacao_cpf")]
    [JsonPropertyName("situacao_cpf")]
    public required string Situacao_cpf { get; set; }

    [JsonProperty("filiacao")]
    [JsonPropertyName("filiacao")]
    public required Filiacao Filiacao { get; set; }

    [JsonProperty("documento")]
    [JsonPropertyName("documento")]
    public required Documento Documento { get; set; }

    [JsonProperty("endereco")]
    [JsonPropertyName("endereco")]
    public required Endereco Endereco { get; set; }

    [JsonProperty("cnh")]
    [JsonPropertyName("cnh")]
    public required Cnh CNH { get; set; }

    [JsonProperty("biometria_face")]
    [JsonPropertyName("biometria_face")]
    public required BiometriaFace BiometriaFace { get; set; }
}

public class BiometriaFace
{
    [JsonProperty("formato")]
    [JsonPropertyName("formato")]
    public required string Formato { get; set; }

    [JsonProperty("base64")]
    [JsonPropertyName("base64")]
    public required string Base64 { get; set; }
}

public class Cnh
{
    [JsonProperty("categoria")]
    [JsonPropertyName("categoria")]
    public required string Categoria { get; set; }

    [JsonProperty("observacoes")]
    [JsonPropertyName("observacoes")]
    public required string Observacoes { get; set; }

    [JsonProperty("numero_registro")]
    [JsonPropertyName("numero_registro")]
    public required string NumeroRegistro { get; set; }

    [JsonProperty("data_primeira_habilitacao")]
    [JsonPropertyName("data_primeira_habilitacao")]
    public required string DataPrimeiraHabilitacao { get; set; }

    [JsonProperty("data_validade")]
    [JsonPropertyName("data_validade")]
    public required string DataValidade { get; set; }

    [JsonProperty("registro_nacional_estrangeiro")]
    [JsonPropertyName("registro_nacional_estrangeiro")]
    public required string RegistroNacionalEstrangeiro { get; set; }

    [JsonProperty("data_ultima_emissao")]
    [JsonPropertyName("data_ultima_emissao")]
    public required string DataUltimaEmissao { get; set; }

    [JsonProperty("codigo_situacao")]
    [JsonPropertyName("codigo_situacao")]
    public required string CodigoSituacao { get; set; }

    [JsonProperty("possui_impedimento")]
    [JsonPropertyName("possui_impedimento")]
    public required bool PossuiImpedimento { get; set; }
}

public class Documento
{
    [JsonProperty("tipo")]
    [JsonPropertyName("tipo")]
    public required string Tipo { get; set; }

    [JsonProperty("numero")]
    [JsonPropertyName("numero")]
    public required string Numero { get; set; }

    [JsonProperty("orgao_expedidor")]
    [JsonPropertyName("orgao_expedidor")]
    public required string Orgao_expedidor { get; set; }

    [JsonProperty("uf_expedidor")]
    [JsonPropertyName("uf_expedidor")]
    public required string UFExpedidor { get; set; }
}

public class Endereco
{
    [JsonProperty("logradouro")]
    [JsonPropertyName("logradouro")]
    public required string Logradouro { get; set; }

    [JsonProperty("numero")]
    [JsonPropertyName("numero")]
    public required string Numero { get; set; }

    [JsonProperty("complemento")]
    [JsonPropertyName("complemento")]
    public required string Complemento { get; set; }

    [JsonProperty("bairro")]
    [JsonPropertyName("bairro")]
    public required string Bairro { get; set; }

    [JsonProperty("cep")]
    [JsonPropertyName("cep")]
    public required string CEP { get; set; }

    [JsonProperty("municipio")]
    [JsonPropertyName("municipio")]
    public required string Municipio { get; set; }

    [JsonProperty("uf")]
    [JsonPropertyName("uf")]
    public required string UF { get; set; }
}

public class Filiacao
{
    [JsonProperty("nome_mae")]
    [JsonPropertyName("nome_mae")]
    public required string NomeMae { get; set; }

    [JsonProperty("nome_pai")]
    [JsonPropertyName("nome_pai")]
    public required string NomePai { get; set; }
}

public class Key
{
    [JsonProperty("cpf")]
    [JsonPropertyName("cpf")]
    public required string CPF { get; set; }
}

