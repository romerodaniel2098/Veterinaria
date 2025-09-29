using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Menus;

public static class VeterinarioMenu
{
    public static void Mostrar(AppDbContext db)
    {
        var service = new VeterinarioService(db);

        Console.WriteLine("\n--- Gestión de Veterinarios ---");
        Console.WriteLine("1. Registrar");
        Console.WriteLine("2. Listar");
        Console.WriteLine("0. Volver");

        var opcion = Console.ReadLine();
        switch (opcion)
        {
            case "1":
                Console.Write("Nombre: "); var nom = Console.ReadLine() ?? "";
                Console.Write("Apellido: "); var ape = Console.ReadLine() ?? "";
                Console.Write("Matrícula: "); var mat = Console.ReadLine() ?? "";
                Console.Write("Teléfono: "); var tel = Console.ReadLine() ?? "";
                service.Registrar(nom, ape, mat, tel);
                break;

            case "2":
                service.Listar().ForEach(v => Console.WriteLine($"{v.Id} - {v.Nombre} {v.Apellido} - Atenciones {v.Atenciones.Count}"));
                break;
        }
    }
}