using Rauteki.Fire.Api.Repositories.Interfaces;
using DataAccess;
using Rauteki.Fire.Api.Repositories.Model;

namespace Rauteki.Fire.Api.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly IDataAccess _dataAccess;

    public ClienteRepository(IDataAccess dataAccess)
    {

        _dataAccess = dataAccess;

    }


    public async Task<decimal> ObterCreditoCliente(int clienteId)
    {
        decimal creditos = await _dataAccess.ExecuteScalarAsync<decimal>(
               "[dbo].[Cliente_Obter_Creditos]",
               new Dictionary<string, object>()
               {
                    {"ClienteId", clienteId}
               }
           );

        return creditos;

    }

    public async Task AtualizaCreditoCliente(int clienteId, decimal valor)
    {
        await _dataAccess.ExecuteScalarAsync<decimal>(
                "[dbo].[Cliente_Atualiza_Credito]",
                new Dictionary<string, object>()
                {
                    {"valor", valor},
                    {"clienteId", clienteId}
                }
            );
    }

    public async Task SalvarConsultaHistorico(int usuarioId, int clienteId, decimal valor, int tipoOperacao)
    {
         await _dataAccess.ExecuteAsync<int>(
                "[dbo].[Cliente_Salvar_ConsultaHistorico]",
                new Dictionary<string, object>()
                {
                    {"usuarioId", usuarioId},
                    {"clienteId", clienteId},
                    {"valor", valor},
                    {"tipoOperacao", tipoOperacao}
                }
            );
                
    }

    public async Task<IEnumerable<CreditoClienteHistorico>> ObterCreditoClienteHistorico(int clienteId)
    {
        IEnumerable<CreditoClienteHistorico> historico = await _dataAccess.ExecuteAsync<CreditoClienteHistorico>(
               "[dbo].[Cliente_Obter_CreditosHistorico]",
               new Dictionary<string, object>()
               {
                    {"ClienteId", clienteId}
               }
           );

        return historico;

    }

}
