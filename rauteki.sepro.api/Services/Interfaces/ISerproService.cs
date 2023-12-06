namespace Rauteki.Sepro.Api.Services.Interfaces;

public interface ISerproService
{
    Task<string> DataValidFacial(string jsonRequest);
}