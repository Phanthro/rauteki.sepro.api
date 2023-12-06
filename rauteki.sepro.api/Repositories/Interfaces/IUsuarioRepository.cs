using Rauteki.Sepro.Api.Features.Login.Commands.LogarPorEmailESenha;
using Rauteki.Sepro.Api.Repositories.Model;

namespace Rauteki.Sepro.Api.Repositories.Interfaces;

public interface IUsuarioRepository
{
    Task<UsuarioPorEmailDto?> ObterPorEmail(LogarPorEmailESenhaDto request);
    Task<IEnumerable<UsuarioPermissaoPagina>> ObterPermissoesPaginaUsuario(int usuarioId);
    
}