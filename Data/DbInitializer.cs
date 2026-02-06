using Microsoft.Data.Sqlite;

namespace CrudSimples.Data;

public static class DbInitializer
{
    public static void Init()
    {
        using var con = Database.GetConnection();
        con.Open();

        var cmd = con.CreateCommand();
        cmd.CommandText = """
            CREATE TABLE IF NOT EXISTS Usuario (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT,
                Email TEXT
            )
        """;

        cmd.ExecuteNonQuery();
    }
}
