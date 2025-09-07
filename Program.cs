using ParkingApp1.Configuration;
using ParkingApp1.ConsoleUI;

// Inicializar datos
Initialization.TodasInicializaciones();

Console.WriteLine("=== Sistema de Parking ===");

// Bucle principal del menú
while (true)
{
    MenuPrincipal.MostrarMenu();
    
    if (int.TryParse(Console.ReadLine(), out int opcion))
    {
        if (opcion == 1)
        {
            Console.WriteLine("\n--- Sistema Inicializado ---");
            Console.WriteLine("Datos cargados desde archivos JSON");
            Console.WriteLine("Plazas, administradores y clientes inicializados");
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
