using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Menus;

public static class ConsultaMenu
{
    public static void Mostrar(AppDbContext db)
    {
        var service = new ConsultaService(db);

        Console.WriteLine("\n--- Consultas Avanzadas ---");
        Console.WriteLine("1. Mascotas de un cliente");
        Console.WriteLine("2. Veterinario con más atenciones");
        Console.WriteLine("3. Especie más atendida");
        Console.WriteLine("4. Cliente con más mascotas");
        Console.WriteLine("0. Volver");

        var opcion = Console.ReadLine();
        switch (opcion)
        {
            case "1":
                Console.Write("Ingrese ID Cliente: ");
                if (int.TryParse(Console.ReadLine(), out int cid))
                    service.MascotasPorCliente(cid);
                break;

            case "2":
                service.VeterinarioConMasAtenciones();
                break;

            case "3":
                service.EspecieMasAtendida();
                break;

            case "4":
                service.ClienteConMasMascotas();
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Opción inválida.");
                break;
        }
    }
}