using Newtonsoft.Json;
using Rauteki.Fire.Api.Services.Interfaces;
using System.ComponentModel;
using System.Text;

namespace Rauteki.Fire.Api.Services;

public class FireService : IFireService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public FireService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string> DataValidFacial(string jsonRequest)
    {
        const string _URL = "https://gateway.apiserpro.serpro.gov.br/datavalid-demonstracao/v3/validate/pf-facial";

        return await ConsultarPostAsync(_URL, jsonRequest, "Data Valid - facial");

    }

    public async Task<string> DataValidDocumento(string jsonRequest)
    {
        const string _URL = "https://gateway.apiserpro.serpro.gov.br/datavalid-demonstracao/v3/validate/pf-facial-cdv";

        return await ConsultarPostAsync(_URL, jsonRequest, "Data Valid - Documento");

    }

    public async Task<string> DividaAtiva(string tipo, string numeroInscricao)
    {
        string _URL = $"https://gateway.apiserpro.serpro.gov.br/consulta-divida-ativa-df-trial/api/v1/{tipo}/{numeroInscricao}";

       return await ConsultarGetAsync(_URL, "Divida Ativa");

    }

    public async Task<string> CNPJ(string tipo, string numeroInscricao)
    {
        string _URL = $"https://gateway.apiserpro.serpro.gov.br/consulta-cnpj-df-trial/v2/{tipo}/{numeroInscricao}";

        return await ConsultarGetAsync(_URL, "CNPJ");
    }

    public async Task<string> CPF(string numeroInscricao)
    {
        string _URL = $"https://gateway.apiserpro.serpro.gov.br/consulta-cpf-df-trial/v1/cpf/{numeroInscricao}";

        return await ConsultarGetAsync(_URL, "CPF");
    }

    
    public async Task<string> CCIR(string tipo, string numero)
    {
        string _URL = "https://gateway.apiserpro.serpro.gov.br/consulta-ccir-trial/v1/";

        if(tipo == "CodigoImovel")
        {
            _URL += "consultarDadosCcirPorCodigoImovel/";
        }
        else
        {
            _URL += "consultarCodigoImovelPorNI/";
        }
        
        _URL = $"{_URL}{numero}";
        
        return await ConsultarGetAsync(_URL, "CCIR");
    }
    
    public async Task<string> CND(string json)
    {
        string _URL = $"https://gateway.apiserpro.serpro.gov.br/consulta-cnd-trial/v1/certidao";
        return await ConsultarPostAsync(_URL, json, "CND");
    }
    
    //Metodos privates

    private async Task<string> ConsultarGetAsync(string _URL, string consulta)
    {
        // string authorization = await Misc.Token.GetToken(_configuration);
        string authorization = "Bearer 06aef429-a981-3ec5-a1f8-71d38d86481e"; //teste
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + authorization);

        HttpResponseMessage response = await _httpClient.GetAsync(_URL);
        if (response.IsSuccessStatusCode)
        {
            string resultado = await response.Content.ReadAsStringAsync();
            return resultado;
        }
        else
        {
            string erroIntegracao = response.Content.ReadAsStringAsync().Result;
            try{
                dynamic erro = JsonConvert.DeserializeObject(erroIntegracao) ?? new {mensagem ="Erro de integração."};
                throw new Exception($"Erro ao obter {consulta}: {erro.mensagem}");
            } catch {throw new Exception($"Erro ao obter {consulta}: {erroIntegracao}");}
        }
    }
    
    private async Task<string> ConsultarPostAsync(string _URL, string jsonRequest, string consulta)
    {
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
            throw new Exception($"Erro ao obter {consulta}: {response.StatusCode}");
        }
    }
    


}