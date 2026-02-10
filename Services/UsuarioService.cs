using System.ComponentModel.DataAnnotations;
using CrudSimples.Data;
using CrudSimples.Models;
using Microsoft.Data.Sqlite;

namespace CrudSimples.Services;

public class UsuarioService
{
    public void Criar(Usuarios usuario)
    {
        using var con = Database.GetConnection();
        con.Open();

        var cmd = con.CreateCommand();
        cmd.CommandText =
            "INSERT INTO Usuarios (nome, Email) VALUES (@nome, @email)";
        cmd.Parameters.AddWithValue("@nome", usuario.Nome);
        cmd.Parameters.AddWithValue("@email", usuario.Email);

        cmd.ExecuteNonQuery();
    }
    // READ
    public List<Usuarios> Listar()
    {
        var usuarios = new List<Usuarios>();

        using var con = Database.GetConnection();
        con.Open();

        var cmd = con.CreateCommand();
        cmd.CommandText = "SELECT * FROM Usuarios";

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            usuarios.Add(new Usuarios
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Email = reader.GetString(2)
            });
        }

        return usuarios;
    }

    // UPDATE

    public void Atualizar(Usuarios usuario)
    {
        using var con = Database.GetConnection();
        con.Open();

        var cmd = con.CreateCommand();
        cmd.CommandText =
            "UPDATE Usuarios SET nome = @nome, Email = @email = WHERE Id = @id";

        cmd.Parameters.AddWithValue("@id", usuario.Id);
        cmd.Parameters.AddWithValue("@nome", usuario.Nome);
        cmd.Parameters.AddWithValue("@email", usuario.Email);

        cmd.ExecuteNonQuery();
    }
    // DELETE
    public void Deletar(int id)
    {
        using var con = Database.GetConnection();
        con.Open();

        var cmd = con.CreateCommand();
        cmd.CommandText = "DELETE FROM Usuarios WHERE Id = @id";
        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
    }
}
