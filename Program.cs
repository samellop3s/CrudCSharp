using CrudSimples.Data;
using CrudSimples.Models;
using CrudSimples.Services;

DbInitializer.Init(); // ⚠️ ISSO PRECISA EXECUTAR PRIMEIRO

var service = new UsuarioService();

// CREATE
service.Criar(new Usuario
{
    Nome = "Samuel",
    Email = "samuel@email.com"
});

// READ
var usuarios = service.Listar();
foreach (var u in usuarios)
{
    Console.WriteLine($"{u.Id} - {u.Nome} - {u.Email}");
}
