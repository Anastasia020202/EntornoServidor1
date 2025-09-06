using ParkingApp1.Models;
using ParkingApp1.ConsoleUI;

// Crear usuarios de ejemplo
Cliente cliente = new Cliente(1, "Juan Pérez", "juan@email.com");
Admin admin = new Admin(2, "María García", "maria@parking.com", "Supervisor");

// Crear plazas de ejemplo
Plaza plazaNormal = new Plaza(1, 2.50m, "Normal");
Plaza plazaPremium = new Plaza(2, 5.00m, "Premium");

// Crear vehículo de ejemplo
Vehiculo vehiculo = new Vehiculo(1, "Toyota", "1234ABC");

// Crear reserva de ejemplo
Reserva reserva = new Reserva(1, 1, 1);

Console.WriteLine("=== Sistema de Parking ===");

// Bucle principal del menú
while (true)
{
    MenuPrincipal.MostrarMenu();
    
    if (int.TryParse(Console.ReadLine(), out int opcion))
    {
        if (opcion == 1)
        {
            Console.WriteLine("\n--- Información del Sistema ---");
            Console.WriteLine("\nUsuarios:");
            cliente.MostrarInfo();
            admin.MostrarInfo();
            
            Console.WriteLine($"\nPlazas:");
            plazaNormal.MostrarInformacion();
            plazaPremium.MostrarInformacion();
            
            Console.WriteLine($"\nVehículo: {vehiculo.Marca} - {vehiculo.Matricula}");
            
            Console.WriteLine($"\nReserva: Usuario {reserva.UsuarioId} -> Plaza {reserva.PlazaId}");
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
