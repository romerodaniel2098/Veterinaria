using Microsoft.EntityFrameworkCore;
using VeterinariaSanMiguel.Models;

namespace VeterinariaSanMiguel.Data;

public class AppDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Mascota> Mascotas { get; set; } = null!;
    public DbSet<Veterinario> Veterinarios { get; set; } = null!;
    public DbSet<AtencionMedica> Atenciones { get; set; } = null!;

    private const string ConnectionString =
        "server=localhost;port=3306;database=veterinaria_db;user=root;password=Qwe.123*;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
    }
}

