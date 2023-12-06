using Rauteki.Sepro.Api.Features.Helpers;
using Rauteki.Sepro.Api.Misc;

namespace Rauteki.Sepro.Api.Features.Login.Commands.LogarPorEmailESenha;

public class LogarPorEmailESenhaDtoValidator : IValidator<LogarPorEmailESenha.Command>
{

    public void Validate(LogarPorEmailESenha.Command request)
    {
        
        AppException ex = new("Erros ao inserir o cadastro PF");

        
        // if(string.IsNullOrEmpty(request.ClientDto.Name)) 
        //     ex.Data.Add("[Name]", "Name of client must be provided."); 

        // if(string.IsNullOrEmpty(request.ClientDto.Name)) 
        //     ex.Data.Add("[BusinessName]", "BusinessName of client must be provided. If there's none, uses the same as the name."); 
        
        // if(request.ClientDto.TIN <= 0) 
        //     ex.Data.Add("[TIN]", "TIN must be provide. (SSN, ITIN, etc..)"); 

        if(ex.Data.Count > 0)
            throw ex;
        
    }
}