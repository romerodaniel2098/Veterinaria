using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Models;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaSanMiguel.Services;

public class MascotaService
{
    private readonly AppDbContext _db;
    public MascotaService(AppDbContext db) => _db = db;

    public void Registrar(string nombre, string especie, string raza, DateTime fechaNacimiento, int clienteId)
    {
        var mascota = new Mascota { Nombre = nombre, Especie = especie, Raza = raza, FechaNacimiento = fechaNacimiento, ClienteId = clienteId };
        _db.Mascotas.Add(mascota);
        _db.SaveChanges();
    }

    public List<Mascota> Listar() =>
        _db.Mascotas.Include(m => m.Cliente).ToList();

    public void Editar(int id, string nuevoNombre)
    {
        var mascota = _db.Mascotas.Find(id);
        if (mascota == null) return;
        mascota.Nombre = nuevoNombre;
        _db.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var mascota = _db.Mascotas.Find(id);
        if (mascota == null) return;
        _db.Mascotas.Remove(mascota);
        _db.SaveChanges();
    }
}