using VeterinariaSanMiguel.Data;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaSanMiguel.Services;

public class ConsultaService
{
    private readonly AppDbContext _db;
    public ConsultaService(AppDbContext db) => _db = db;

    public void MascotasPorCliente(int clienteId)
    {
        var mascotas = _db.Mascotas.Where(m => m.ClienteId == clienteId).ToList();
        mascotas.ForEach(m => Console.WriteLine($"{m.Nombre} ({m.Especie})"));
    }

    public void VeterinarioConMasAtenciones()
    {
        var vet = _db.Veterinarios
            .Select(v => new { v.Nombre, v.Apellido, Total = v.Atenciones.Count })
            .OrderByDescending(v => v.Total).FirstOrDefault();
        Console.WriteLine(vet == null ? "No hay datos." : $"{vet.Nombre} {vet.Apellido} - {vet.Total} atenciones");
    }

    public void EspecieMasAtendida()
    {
        var especie = _db.Mascotas.GroupBy(m => m.Especie)
            .Select(g => new { Especie = g.Key, Count = g.Count() })
            .OrderByDescending(g => g.Count).FirstOrDefault();
        Console.WriteLine(especie == null ? "No hay datos." : $"{especie.Especie} - {especie.Count} mascotas");
    }

    public void ClienteConMasMascotas()
    {
        var cliente = _db.Clientes
            .Select(c => new { c.Nombre, Total = c.Mascotas.Count })
            .OrderByDescending(c => c.Total).FirstOrDefault();
        Console.WriteLine(cliente == null ? "No hay datos." : $"{cliente.Nombre} - {cliente.Total} mascotas");
    }
}