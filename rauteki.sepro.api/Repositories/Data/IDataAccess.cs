using System.Data;

namespace DataAccess;

public interface IDataAccess
{
    Task<IEnumerable<T>> ExecuteAsync<T>(string query);
    Task<IEnumerable<T>> ExecuteAsync<T>(string query, Dictionary<string, object> parameters);
    Task<T> ExecuteScalarAsync<T>(string query, Dictionary<string, object> parameters);
}
