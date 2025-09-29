namespace VeterinariaSanMiguel.Models;

public class Mascota
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public DateTime FechaNacimiento { get; set; }
    public string Especie { get; set; } = "";
    public string Raza { get; set; } = "";

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;

    public List<AtencionMedica> Atenciones { get; set; } = new();
}