using DuckDB.NET.Data;

namespace FileSorter.Extensions;

public static class DbExtensions
{
    public static int ExecuteNonQuery(this DuckDBConnection connection, string sql)
    {
        using DuckDBCommand cmd = connection.CreateCommand();
        cmd.CommandText = sql;
    
        return cmd.ExecuteNonQuery();
    }

    public static List<T> ExecuteReader<T>(
        this DuckDBConnection connection, string sql, Func<DuckDBDataReader, T> mapper) 
    {
        using DuckDBCommand cmd = connection.CreateCommand();
        cmd.CommandText = sql;
        cmd.CommandText = sql;
        
        List<T> result = new();
        using DuckDBDataReader reader = cmd.ExecuteReader();

        while (reader.NextResult())
        {
            result.Add(mapper.Invoke(reader));
        }

        return result;
    }
}
