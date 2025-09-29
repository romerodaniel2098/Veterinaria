using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Models;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaSanMiguel.Services;

public class VeterinarioService
{
    private readonly AppDbContext _db;
    public VeterinarioService(AppDbContext db) => _db = db;

    public void Registrar(string nombre, string apellido, string matricula, string telefono)
    {
        var vet = new Veterinario { Nombre = nombre, Apellido = apellido, Matricula = matricula, Telefono = telefono };
        _db.Veterinarios.Add(vet);
        _db.SaveChanges();
    }

    public List<Veterinario> Listar() =>
        _db.Veterinarios.Include(v => v.Atenciones).ToList();
}