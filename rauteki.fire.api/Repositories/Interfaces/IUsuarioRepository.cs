using Rauteki.Fire.Api.Features.Login.Commands.LogarPorEmailESenha;
using Rauteki.Fire.Api.Features.Usuario.Commands.AlterarUsuario;
using Rauteki.Fire.Api.Features.Usuario.Commands.CriarNovoUsuario;
using Rauteki.Fire.Api.Repositories.Model;

namespace Rauteki.Fire.Api.Repositories.Interfaces;

public interface IUsuarioRepository
{
    Task<UsuarioPorEmailDto?> ObterPorEmail(LogarPorEmailESenhaDto request);
    Task<IEnumerable<UsuarioPermissaoPagina>> ObterPermissoesPaginaUsuario(int usuarioId);
    Task<IEnumerable<Usuario>> ListarUsuarios(int clienteId);
    Task<Usuario?> ObterUsuarioById(int usuarioId);
    Task<int> CriarNovoUsuario(CriarNovoUsuarioDto usuario);
    Task<int> AlterarUsuario(AlterarUsuarioDto usuario);
    Task DesativarUsuario(int usuarioId);
    Task<decimal> ObterCreditoUsuario(int usuarioId);
    Task<IEnumerable<CreditoUsuarioHistorico>> ObterCreditoUsuarioHistorico(int usuarioId);
    Task AtualizaCreditoUsuario(int usuarioId, decimal valor);
    Task SalvarConsultaHistorico(int usuarioId, decimal valor, int tipoOperacao);
    
}