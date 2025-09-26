using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Menus;

class Program
{
    static void Main()
    {
        using var db = new AppDbContext();

        Console.WriteLine("=== Veterinaria San Miguel - Consola ===");

        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- Menú Principal ---");
            Console.WriteLine("1. Gestión de Clientes");
            Console.WriteLine("2. Gestión de Mascotas");
            Console.WriteLine("3. Gestión de Veterinarios");
            Console.WriteLine("4. Gestión de Atenciones Médicas");
            Console.WriteLine("5. Consultas Avanzadas (LINQ)");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": ClienteMenu.Mostrar(db); break;
                case "2": MascotaMenu.Mostrar(db); break;
                case "3": VeterinarioMenu.Mostrar(db); break;
                case "4": AtencionMenu.Mostrar(db); break;
                case "5": ConsultaMenu.Mostrar(db); break;
                case "0": salir = true; break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }
    }
}