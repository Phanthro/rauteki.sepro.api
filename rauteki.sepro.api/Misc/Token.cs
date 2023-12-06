
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Rauteki.Sepro.Api.Misc;

public static class Token
{
    static string token = "";
    static DateTime ultimaConsulta;

    private static readonly HttpClient _httpClient = new();

    public static async Task<string> GetToken(IConfiguration configuration)
    {
        const string _URL = "https://gateway.apiserpro.serpro.gov.br/token";


        string key = configuration["Serpro:APIPublicKey"]??throw new Exception("Nenhuma chave encontrada");
        string secret = configuration["Serpro:APISecretKey"]??throw new Exception("Nenhum segredo encontrada");

        string authorization = $"Basic {StringToBase64(key + ":" + secret)}";
        _httpClient.DefaultRequestHeaders.Add("Authorization", authorization);

        StringContent corpoRequisicao = new(
            JsonConvert.SerializeObject(new { grant_type = "client_credentials" })
            , Encoding.UTF8,
            "application/x-www-form-urlencoded"
            );

        try
        {
            HttpResponseMessage response = await _httpClient.PostAsync(_URL, corpoRequisicao);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(content))
                    throw new Exception("Erro ao obter token(1)");

                dynamic result = JsonConvert.DeserializeObject(content) ?? "{}";
                ultimaConsulta = DateTime.Now.AddSeconds(result.expires_in);
                token = result.access_token;

                return token;

            }
            else
            {
                throw new Exception("Erro na chamada API. Código de status: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: " + ex.Message);
        }

    }

    static string StringToBase64(string texto)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(texto);
        string base64String = Convert.ToBase64String(bytes);
        return base64String;
    }
    
}
