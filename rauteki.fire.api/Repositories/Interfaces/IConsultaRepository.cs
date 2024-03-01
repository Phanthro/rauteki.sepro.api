using Rauteki.Fire.Api.Repositories.Model;

namespace Rauteki.Fire.Api.Repositories.Interfaces;

public interface IConsultaRepository
{
    Task<IEnumerable<Consulta>> ObterConsultas();
    Task SalvarConsultaHistorico(int usuarioId, int consultaId, string cpf, string requisicao, string resposta);
    Task<IEnumerable<ConsultaHistorico>> ObterConsultasUsuarioHistorico(int usuarioId, int consultaHistoricoId);
    
}