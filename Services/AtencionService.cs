using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Models;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaSanMiguel.Services;

public class AtencionService
{
    private readonly AppDbContext _db;
    public AtencionService(AppDbContext db) => _db = db;

    public void Registrar(int mascotaId, int veterinarioId, string diagnostico)
    {
        var atencion = new AtencionMedica
        {
            MascotaId = mascotaId,
            VeterinarioId = veterinarioId,
            Diagnostico = diagnostico,
            FechaAtencion = DateTime.Now
        };
        _db.Atenciones.Add(atencion);
        _db.SaveChanges();
    }

    public List<AtencionMedica> Listar() =>
        _db.Atenciones.Include(a => a.Mascota).Include(a => a.Veterinario).ToList();
}