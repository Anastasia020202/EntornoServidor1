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
            MenuPrincipal.VerPlazas();
        }
        else if (opcion == 2)
        {
            var sesion = MenuPrincipal.IniciarSesion();
            if (sesion.EstaActiva)
            {
                Console.WriteLine("Sesión iniciada correctamente");
                // Aquí irían los menús específicos según el rol
            }
            Console.WriteLine("\nPresiona Enter para continuar...");
            Console.ReadLine();
        }
        else if (opcion == 3)
        {
            MenuPrincipal.Registrarse();
            Console.WriteLine("\nPresiona Enter para continuar...");
            Console.ReadLine();
        }
        else if (opcion == 4)
        {
            Console.WriteLine("¡Hasta la próxima!");
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
