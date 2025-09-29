namespace VeterinariaSanMiguel.Models;

public class Veterinario : Persona
{
    public string Matricula { get; set; } = "";
    public string Telefono { get; set; } = "";

    public List<AtencionMedica> Atenciones { get; set; } = new();
}