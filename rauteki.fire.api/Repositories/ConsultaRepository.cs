using Rauteki.Fire.Api.Repositories.Interfaces;
using DataAccess;
using Rauteki.Fire.Api.Repositories.Model;

namespace Rauteki.Fire.Api.Repositories;

public class ConsultaRepository : IConsultaRepository
{
    private readonly IDataAccess _dataAccess;
    
    public ConsultaRepository(IDataAccess dataAccess)
    {

        _dataAccess = dataAccess;
        
    }


    public async Task<IEnumerable<Consulta>> ObterConsultas()
    {
         IEnumerable<Consulta> consultas = await _dataAccess.ExecuteAsync<Consulta>(
                "[dbo].[Consultas_Obter_Consultas]"
            );
        
        return consultas;
        
    }
    
    public async Task SalvarConsultaHistorico(int usuarioId, int consultaId, string cpf, string requisicao, string resposta)
    {
         await _dataAccess.ExecuteAsync<int>(
                "[dbo].[Consultas_Salvar_ConsultaHistorico]",
                new Dictionary<string, object>()
                {
                    {"usuarioId", usuarioId},
                    {"consultaId", consultaId},
                    {"cpf", cpf},
                    {"requisicao", requisicao},
                    {"resposta", resposta}
                }
            );
                
    }

    public async Task<IEnumerable<ConsultaHistorico>> ObterConsultasUsuarioHistorico(int usuarioId, int consultaHistoricoId)
    {

        IEnumerable<ConsultaHistorico> historico = await _dataAccess.ExecuteAsync<ConsultaHistorico>(
               "[dbo].[Consultas_Obter_UsuarioHistorico]",
               new Dictionary<string, object>()
               {
                    {"UsuarioId", usuarioId},
                    {"ConsultaHistoricoId", consultaHistoricoId}
               }
           );

        return historico;

    }
    
}
