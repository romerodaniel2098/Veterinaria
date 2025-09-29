using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Models;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaSanMiguel.Services;

public class ClienteService
{
    private readonly AppDbContext _db;

    public ClienteService(AppDbContext db) => _db = db;

    public void RegistrarCliente(string nombre, string apellido, string telefono, string direccion)
    {
        var cliente = new Cliente { Nombre = nombre, Apellido = apellido, Telefono = telefono, Direccion = direccion };
        _db.Clientes.Add(cliente);
        _db.SaveChanges();
    }

    public List<Cliente> ListarClientes() =>
        _db.Clientes.Include(c => c.Mascotas).ToList();

    public void EditarCliente(int id, string nuevoNombre, string nuevoTelefono)
    {
        var cliente = _db.Clientes.Find(id);
        if (cliente == null) return;

        cliente.Nombre = nuevoNombre;
        cliente.Telefono = nuevoTelefono;
        _db.SaveChanges();
    }

    public void EliminarCliente(int id)
    {
        var cliente = _db.Clientes.Include(c => c.Mascotas).FirstOrDefault(c => c.Id == id);
        if (cliente == null) return;

        _db.Clientes.Remove(cliente);
        _db.SaveChanges();
    }
}