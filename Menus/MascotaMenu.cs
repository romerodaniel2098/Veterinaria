using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Menus;

public static class MascotaMenu
{
    public static void Mostrar(AppDbContext db)
    {
        var service = new MascotaService(db);

        Console.WriteLine("\n--- Gestión de Mascotas ---");
        Console.WriteLine("1. Registrar");
        Console.WriteLine("2. Listar");
        Console.WriteLine("3. Editar");
        Console.WriteLine("4. Eliminar");
        Console.WriteLine("0. Volver");

        var opcion = Console.ReadLine();
        switch (opcion)
        {
            case "1":
                Console.Write("Nombre: "); var nom = Console.ReadLine() ?? "";
                Console.Write("Especie: "); var esp = Console.ReadLine() ?? "";
                Console.Write("Raza: "); var raza = Console.ReadLine() ?? "";
                Console.Write("Fecha nacimiento (yyyy-MM-dd): ");
                DateTime fecha = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());
                Console.Write("Cliente ID: "); int cid = int.Parse(Console.ReadLine() ?? "0");
                service.Registrar(nom, esp, raza, fecha, cid);
                break;

            case "2":
                service.Listar().ForEach(m => Console.WriteLine($"{m.Id} - {m.Nombre} ({m.Especie}) - Cliente {m.Cliente?.Nombre}"));
                break;

            case "3":
                Console.Write("ID Mascota: "); int idE = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Nuevo nombre: "); var nuevoNom = Console.ReadLine() ?? "";
                service.Editar(idE, nuevoNom);
                break;

            case "4":
                Console.Write("ID Mascota: "); int idD = int.Parse(Console.ReadLine() ?? "0");
                service.Eliminar(idD);
                break;
        }
    }
}