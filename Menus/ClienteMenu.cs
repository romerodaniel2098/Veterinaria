using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Menus;

public static class ClienteMenu
{
    public static void Mostrar(AppDbContext db)
    {
        var service = new ClienteService(db);

        Console.WriteLine("\n--- Gestión de Clientes ---");
        Console.WriteLine("1. Registrar Cliente");
        Console.WriteLine("2. Listar Clientes");
        Console.WriteLine("3. Editar Cliente");
        Console.WriteLine("4. Eliminar Cliente");
        Console.WriteLine("0. Volver");
        Console.Write("Opción: ");
        var opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                Console.Write("Nombre: "); var nom = Console.ReadLine() ?? "";
                Console.Write("Apellido: "); var ape = Console.ReadLine() ?? "";
                Console.Write("Teléfono: "); var tel = Console.ReadLine() ?? "";
                Console.Write("Dirección: "); var dir = Console.ReadLine() ?? "";
                service.RegistrarCliente(nom, ape, tel, dir);
                Console.WriteLine("Cliente registrado.");
                break;

            case "2":
                var clientes = service.ListarClientes();
                clientes.ForEach(c => Console.WriteLine($"{c.Id} - {c.ObtenerInfo(true)}"));
                break;

            case "3":
                Console.Write("ID Cliente: ");
                if (int.TryParse(Console.ReadLine(), out int idEdit))
                {
                    Console.Write("Nuevo Nombre: "); var nuevoNom = Console.ReadLine() ?? "";
                    Console.Write("Nuevo Teléfono: "); var nuevoTel = Console.ReadLine() ?? "";
                    service.EditarCliente(idEdit, nuevoNom, nuevoTel);
                    Console.WriteLine("Cliente actualizado.");
                }
                break;

            case "4":
                Console.Write("ID Cliente: ");
                if (int.TryParse(Console.ReadLine(), out int idDel))
                {
                    service.EliminarCliente(idDel);
                    Console.WriteLine("Cliente eliminado.");
                }
                break;
        }
    }
}
