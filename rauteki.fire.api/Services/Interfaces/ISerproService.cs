namespace Rauteki.Fire.Api.Services.Interfaces;

public interface IFireService
{
    Task<string> DataValidFacial(string jsonRequest);
    Task<string> DataValidDocumento(string jsonRequest);
    Task<string> DividaAtiva(string tipo, string numeroInscricao);
    Task<string> CNPJ(string tipo, string numeroInscricao);
    Task<string> CPF(string numeroInscricao);
    Task<string> CCIR(string tipo, string numero);
    Task<string> CND(string json);
}