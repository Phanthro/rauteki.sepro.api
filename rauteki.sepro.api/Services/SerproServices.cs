using Newtonsoft.Json;
using Rauteki.Sepro.Api.Services.Interfaces;
using System.Net.Http;
using System.Text;

namespace Rauteki.Sepro.Api.Services;

public class SerproService : ISerproService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public SerproService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string> DataValidFacial(string jsonRequest)
    {
        const string _URL = "https://gateway.apiserpro.serpro.gov.br/datavalid-demonstracao/v3/validate/pf-facial";

        // string authorization = await Misc.Token.GetToken(_configuration);
        string authorization = "Bearer 06aef429-a981-3ec5-a1f8-71d38d86481e"; //teste
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + authorization);

        StringContent payload = new(
            jsonRequest
            , Encoding.UTF8,
            "application/json"
            );

        HttpResponseMessage response = await _httpClient.PostAsync(_URL, payload);
        if (response.IsSuccessStatusCode)
        {
            string resultado = await response.Content.ReadAsStringAsync();
            return resultado;
        }
        else
        {
            throw new Exception($"Erro ao obter validação de identidade(1): {response.StatusCode}");
        }

    }
}