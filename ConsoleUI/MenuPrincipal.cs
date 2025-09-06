namespace ParkingApp1.ConsoleUI;

public class MenuPrincipal
{
    public static void MostrarMenu()
    {
        Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Ver información de usuario");
        Console.WriteLine("2. Salir");
        Console.WriteLine("========================");
        Console.Write("Selecciona una opción: ");
    }

    public static void EjecutarOpcion(int opcion)
    {
        switch (opcion)
        {
            case 1:
                Console.WriteLine("\n--- Información del Usuario ---");
                // Aquí mostraremos la información del usuario
                break;
            case 2:
                Console.WriteLine("¡Hasta luego!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                break;
        }
    }
}
