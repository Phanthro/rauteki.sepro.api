using Rauteki.Fire.Api.Features.Login.Commands.LogarPorEmailESenha;
using Rauteki.Fire.Api.Repositories.Model;

namespace Rauteki.Fire.Api.Repositories.Interfaces;

public interface IDominioRepository
{
    Task<IEnumerable<Dominio>> ObterCNPJDominios();
    
}