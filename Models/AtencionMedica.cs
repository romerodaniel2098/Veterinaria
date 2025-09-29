namespace VeterinariaSanMiguel.Models;

public class AtencionMedica
{
    public int Id { get; set; }
    public DateTime FechaAtencion { get; set; } = DateTime.Now;
    public string Diagnostico { get; set; } = "";

    public int MascotaId { get; set; }
    public Mascota Mascota { get; set; } = null!;

    public int VeterinarioId { get; set; }
    public Veterinario Veterinario { get; set; } = null!;
}