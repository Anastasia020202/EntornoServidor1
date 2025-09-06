using ParkingApp1.Models;
using ParkingApp1.ConsoleUI;

// Crear un usuario de ejemplo
Usuario usuario = new Usuario(1, "Juan Pérez");

Console.WriteLine("=== Sistema de Parking ===");

// Bucle principal del menú
while (true)
{
    MenuPrincipal.MostrarMenu();
    
    if (int.TryParse(Console.ReadLine(), out int opcion))
    {
        if (opcion == 1)
        {
            Console.WriteLine("\n--- Información del Usuario ---");
            usuario.MostrarInfo();
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
