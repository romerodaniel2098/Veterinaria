using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Menus;

public static class AtencionMenu
{
    public static void Mostrar(AppDbContext db)
    {
        var service = new AtencionService(db);

        Console.WriteLine("\n--- Gestión de Atenciones ---");
        Console.WriteLine("1. Registrar");
        Console.WriteLine("2. Listar");
        Console.WriteLine("0. Volver");

        var opcion = Console.ReadLine();
        switch (opcion)
        {
            case "1":
                Console.Write("Mascota ID: "); int mid = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Veterinario ID: "); int vid = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Diagnóstico: "); var dx = Console.ReadLine() ?? "";
                service.Registrar(mid, vid, dx);
                break;

            case "2":
                service.Listar().ForEach(a => Console.WriteLine($"{a.Id} - {a.Mascota?.Nombre} atendida por {a.Veterinario?.Nombre} - Dx: {a.Diagnostico}"));
                break;
        }
    }
}