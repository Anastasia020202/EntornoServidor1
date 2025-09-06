using ParkingApp1.Models;
using ParkingApp1.ConsoleUI;

// Crear usuarios de ejemplo
Cliente cliente = new Cliente(1, "Juan Pérez", "juan@email.com");
Admin admin = new Admin(2, "María García", "maria@parking.com", "Supervisor");

Console.WriteLine("=== Sistema de Parking ===");

// Bucle principal del menú
while (true)
{
    MenuPrincipal.MostrarMenu();
    
    if (int.TryParse(Console.ReadLine(), out int opcion))
    {
        if (opcion == 1)
        {
            Console.WriteLine("\n--- Información de Usuarios ---");
            Console.WriteLine("\nCliente:");
            cliente.MostrarInfo();
            Console.WriteLine("\nAdministrador:");
            admin.MostrarInfo();
        }
        else if (opcion == 2)
        {
            Console.WriteLine("¡Hasta luego!");
            break;
        }
        else
        {
            Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
        }
    }
    else
    {
        Console.WriteLine("Por favor, introduce un número válido.");
    }
}
