using Rauteki.Fire.Api.Repositories.Interfaces;
using DataAccess;
using Rauteki.Fire.Api.Repositories.Model;

namespace Rauteki.Fire.Api.Repositories;

public class DominioRepository : IDominioRepository
{
    private readonly IDataAccess _dataAccess;

    public DominioRepository(IDataAccess dataAccess)
    {

        _dataAccess = dataAccess;

    }

    public async Task<IEnumerable<Dominio>> ObterCNPJDominios()
    {
         var creditos = await _dataAccess.ExecuteAsync<Dominio>(
               "[dbo].[Dominios_Obter_CNPJ]");

        return creditos;
    }

}