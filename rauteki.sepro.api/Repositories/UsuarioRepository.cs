using Rauteki.Sepro.Api.Features.Login.Commands.LogarPorEmailESenha;
using Rauteki.Sepro.Api.Repositories.Interfaces;
using Rauteki.Sepro.Api.Repositories.Model;
using DataAccess;

namespace Rauteki.Sepro.Api.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IDataAccess _dataAccess;
    
    public UsuarioRepository(IDataAccess dataAccess)
    {

        _dataAccess = dataAccess;
        
    }

    public async Task<UsuarioPorEmailDto?> ObterPorEmail(LogarPorEmailESenhaDto request)
    {
         UsuarioPorEmailDto? user = (await _dataAccess.ExecuteAsync<UsuarioPorEmailDto>(
                "[dbo].[Usuario_Obter_PorEmail]",
                new Dictionary<string, object>()
                {
                    {"Email", request.Email}
                }
            )).FirstOrDefault();
        
        return user;
        
    }

    public async Task<IEnumerable<UsuarioPermissaoPagina>> ObterPermissoesPaginaUsuario(int usuarioId)
    {
         IEnumerable<UsuarioPermissaoPagina> permissoes = await _dataAccess.ExecuteAsync<UsuarioPermissaoPagina>(
                "[dbo].[Usuario_Obter_PermissoesPagina]",
                new Dictionary<string, object>()
                {
                    {"UsuarioId", usuarioId}
                }
            );
        
        return permissoes;
        
    }

}
