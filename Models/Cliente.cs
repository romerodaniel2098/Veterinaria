namespace VeterinariaSanMiguel.Models;

public class Cliente : Persona
{
    public string Telefono { get; set; } = "";
    public string Direccion { get; set; } = "";

    public List<Mascota> Mascotas { get; set; } = new();

    // Ejemplo de sobrecarga de métodos
    public string ObtenerInfo() => ObtenerInfo(false);

    public string ObtenerInfo(bool incluirMascotas)
    {
        var info = $"{Nombre} {Apellido} - Tel: {Telefono}";
        if (incluirMascotas && Mascotas.Any())
        {
            info += "\nMascotas:";
            Mascotas.ForEach(m => info += $"\n - {m.Nombre} ({m.Especie})");
        }
        return info;
    }
}