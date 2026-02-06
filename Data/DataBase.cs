using Microsoft.Data.Sqlite;

namespace CrudSimples.Data;

public class Database
{
    public static SqliteConnection GetConnection()
    {
        return new SqliteConnection("Data Source=crud.db");
    }
}
