using Rauteki.Fire.Api.Features.Login.Commands.LogarPorEmailESenha;
using Rauteki.Fire.Api.Repositories.Interfaces;
using Rauteki.Fire.Api.Repositories.Model;
using DataAccess;
using Rauteki.Fire.Api.Features.Usuario.Commands.CriarNovoUsuario;
using Rauteki.Fire.Api.Features.Usuario.Commands.AlterarUsuario;

namespace Rauteki.Fire.Api.Repositories;

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

    public async Task<IEnumerable<Usuario>> ListarUsuarios(int clienteId)
    {
         IEnumerable<Usuario>? user = await _dataAccess.ExecuteAsync<Usuario>(
                "[dbo].[Usuario_Listar_PorClienteId]",
                new Dictionary<string, object>(){
                    {"ClienteId", clienteId}
                }
            );
        
        return user;
        
    }

    public async Task<Usuario?> ObterUsuarioById(int usuarioId)
    {
         Usuario? user = (await _dataAccess.ExecuteAsync<Usuario>(
                "[dbo].[Usuario_Obter_PorUsuarioId]",
                new Dictionary<string, object>(){
                    {"UsuarioId", usuarioId}
                }
            )).FirstOrDefault();
        
        return user;
        
    }

    public async Task<int> CriarNovoUsuario(CriarNovoUsuarioDto usuario)
    {
        int usuarioId = await _dataAccess.ExecuteScalarAsync<int>(
                "[dbo].[Usuario_Inserir_Usuario]",
                ConverterDto(usuario)
            );
        
        return usuarioId;
    }

    public async Task<int> AlterarUsuario(AlterarUsuarioDto usuario)
    {
        int usuarioId = await _dataAccess.ExecuteScalarAsync<int>(
                "[dbo].[Usuario_Alterar_Usuario]",
                ConverterDto(usuario)
            );
        
        return usuarioId;
    }

    public async Task DesativarUsuario(int usuarioId)
    {
        await _dataAccess.ExecuteScalarAsync<int>(
                "[dbo].[Usuario_Desativar_Usuario]",
                new Dictionary<string, object>()
                {
                    {"UsuarioId", usuarioId}
                }
            );
        
        return;
    }

    public async Task<decimal> ObterCreditoUsuario(int usuarioId)
    {
        decimal creditos = await _dataAccess.ExecuteScalarAsync<decimal>(
               "[dbo].[Usuario_Obter_Creditos]",
               new Dictionary<string, object>()
               {
                    {"UsuarioId", usuarioId}
               }
           );

        return creditos;

    }

    public async Task<IEnumerable<CreditoUsuarioHistorico>> ObterCreditoUsuarioHistorico(int usuarioId)
    {
        IEnumerable<CreditoUsuarioHistorico> historico = await _dataAccess.ExecuteAsync<CreditoUsuarioHistorico>(
               "[dbo].[Usuario_Obter_CreditosHistorico]",
               new Dictionary<string, object>()
               {
                    {"UsuarioId", usuarioId}
               }
           );

        return historico;

    }

    public async Task AtualizaCreditoUsuario(int usuarioId, decimal valor)
    {
        await _dataAccess.ExecuteScalarAsync<decimal>(
                "[dbo].[Usuario_Atualiza_Credito]",
                new Dictionary<string, object>()
                {
                    {"usuarioId", usuarioId},
                    {"valor", valor}
                }
            );
    }

    public async Task SalvarConsultaHistorico(int usuarioId, decimal valor, int tipoOperacao)
    {
         await _dataAccess.ExecuteAsync<int>(
                "[dbo].[Usuario_Salvar_ConsultaHistorico]",
                new Dictionary<string, object>()
                {
                    {"usuarioId", usuarioId},
                    {"valor", valor},
                    {"tipoOperacao", tipoOperacao}
                }
            );
                
    }


    
    /// privates
    private Dictionary<string, object> ConverterDto(CriarNovoUsuarioDto usuario)
    {
        
        return new Dictionary<string, object>()
        {
            {"ClienteId", usuario.ClienteId},
            {"Email", usuario.Email},
            {"Nome", usuario.Nome},
            {"Senha", usuario.Senha},
            {"Telefone", usuario.Telefone},
            {"CriadoEm", DateTime.Now.ToString("yyyy-MM-dd")},
        };
    }

    private Dictionary<string, object> ConverterDto(AlterarUsuarioDto usuario)
    {
        
        return new Dictionary<string, object>()
        {
            {"UsuarioId", usuario.UsuarioId},
            {"Email", usuario.Email},
            {"Nome", usuario.Nome},
            {"Senha", usuario.Senha},
            {"Telefone", usuario.Telefone}
        };
    }

}
