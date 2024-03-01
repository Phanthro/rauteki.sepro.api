using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace DataAccess;

public class DataAccess : IDataAccess
{
    private readonly IConfiguration _configuration;

    public DataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    

    public async Task<IEnumerable<T>> ExecuteAsync<T>(string query) 
    {
        IEnumerable<T>? result;
        using (SqlConnection connection = new(_configuration.GetConnectionString("default")))
        {
            using SqlCommand command = new(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            string dbResult = await command.ExecuteToJson();
            result = JsonConvert.DeserializeObject<IEnumerable<T>>(dbResult);
        }

        return result ?? throw new NullReferenceException("Returning null");

    }

    public async Task<IEnumerable<T>> ExecuteAsync<T>(string query, Dictionary<string, object> parameters)
    {
        IEnumerable<T>? result;
        using (SqlConnection connection = new(_configuration.GetConnectionString("default")))
        {
            using SqlCommand command = new(query, connection);
            command.AddParameters(parameters);
            command.CommandType = CommandType.StoredProcedure;
            string dbResult = await command.ExecuteToJson();
            result = JsonConvert.DeserializeObject<IEnumerable<T>>(dbResult);
        }

        return result ?? throw new NullReferenceException("Returning null");;

    }

    public async Task<T> ExecuteScalarAsync<T>(string query, Dictionary<string, object> parameters)
    {
        T? result;

        if(!typeof(T).IsPrimitive && typeof(T) != typeof(string )&& typeof(T) != typeof(decimal))  throw new Exception("Type is not primitive");

        using (SqlConnection connection = new(_configuration.GetConnectionString("default")))
        {
            using SqlCommand command = new(query, connection);
            command.AddParameters(parameters);
            command.CommandType = CommandType.StoredProcedure;
            if(command.Connection.State == ConnectionState.Closed)
                command.Connection.Open();
            var r = await command.ExecuteScalarAsync();
            result = (T?)(r??default(T));
        }

        return result ?? throw new NullReferenceException("Returning null");;

    }

    public async Task<int> ExecuteNoQueryAsync<T>(string query)
    {
        int result;
        using (SqlConnection connection = new(_configuration.GetConnectionString("default")))
        {
            using SqlCommand command = new(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            result = await command.ExecuteNonQueryAsync();
        }

        return result;

    }
    
}


public static class SqlExtension
{
    public static Task<string> ExecuteToJson(this SqlCommand cmd)
    {
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }

        using DataTable dt = new();
        using SqlDataAdapter da = new(cmd);
        da.Fill(dt);

        List<Dictionary<string, object>> rows = new();
        Dictionary<string, object> row;
        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }

        return Task.FromResult(JsonConvert.SerializeObject(rows));
    }

    public static void AddParameters(this SqlCommand cmd, Dictionary<string, object> parameters)
    {
        foreach (var param in parameters)
        {
            var p = new SqlParameter(){
                ParameterName = param.Key,
                Value = param.Value
            };
            cmd.Parameters.Add(p);
        }
    }

}
