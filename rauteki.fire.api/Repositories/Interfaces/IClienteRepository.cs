using Rauteki.Fire.Api.Features.Login.Commands.LogarPorEmailESenha;
using Rauteki.Fire.Api.Repositories.Model;

namespace Rauteki.Fire.Api.Repositories.Interfaces;

public interface IClienteRepository
{
    Task<decimal> ObterCreditoCliente(int clienteId);
    Task AtualizaCreditoCliente(int clienteId, decimal valor);
    Task SalvarConsultaHistorico(int usuarioId, int clienteId, decimal valor, int tipoOperacao);
    Task<IEnumerable<CreditoClienteHistorico>> ObterCreditoClienteHistorico(int clienteId);
    
}