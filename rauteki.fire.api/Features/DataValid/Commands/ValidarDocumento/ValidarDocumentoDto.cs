using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Rauteki.Fire.Api.Features.DataValid.Commands.ValidarDocumento;

public class ValidarDocumentoDto
{
    [JsonProperty("key")]
    [JsonPropertyName("key")]
    public required ValidarDocumentoKey Key { get; set; }

    [JsonProperty("answer")]
    [JsonPropertyName("answer")]
    public required ValidarDocumentoAnswer Answer { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public int ClienteId { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public int UsuarioId { get; set; }
}

public class ValidarDocumentoAnswer
{

    [JsonProperty("documento")]
    [JsonPropertyName("documento")]
    public required Foto Documento { get; set; }

    [JsonProperty("documento_verso")]
    [JsonPropertyName("documento_verso")]
    public required Foto DocumentoVerso { get; set; }

    [JsonProperty("biometria_face")]
    [JsonPropertyName("biometria_face")]
    public required Foto BiometriaFace { get; set; }
}

public class Foto
{
    [JsonProperty("formato")]
    [JsonPropertyName("formato")]
    public required string Formato { get; set; }

    [JsonProperty("base64")]
    [JsonPropertyName("base64")]
    public required string Base64 { get; set; }
}

public class ValidarDocumentoKey
{
    [JsonProperty("cpf")]
    [JsonPropertyName("cpf")]
    public required string CPF { get; set; }
}

