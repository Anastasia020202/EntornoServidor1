using ParkingApp1.Models;
using ParkingApp1.Repositories;
using ParkingApp1.Services;

namespace ParkingApp1.ConsoleUI;

public class MenuCliente
{
    public static void MostrarMenu(Sesion sesion)
    {
        Console.WriteLine("\n=== MENÚ CLIENTE ===");
        Console.WriteLine($"Bienvenido, {sesion.UsuarioActivo?.Nombre}");
        Console.WriteLine("1. Ver mis reservas");
        Console.WriteLine("2. Ver plazas disponibles");
        Console.WriteLine("3. Hacer reserva");
        Console.WriteLine("4. Cancelar reserva");
        Console.WriteLine("5. Registrar vehículo");
        Console.WriteLine("6. Cerrar sesión");
        Console.WriteLine("=====================");
        Console.Write("Selecciona una opción: ");
    }

    public static void VerMisReservas(Sesion sesion)
    {
        Console.WriteLine("\n--- MIS RESERVAS ---");
        try
        {
            var reservas = ReservaRepository.CargarReservas();
            var misReservas = reservas.Where(r => r.UsuarioId == sesion.UsuarioActivo?.Id).ToList();
            
            if (misReservas.Any())
            {
                foreach (var reserva in misReservas)
                {
                    reserva.MostrarDetalles();
                }
            }
            else
            {
                Console.WriteLine("No tienes reservas activas.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al cargar reservas: {e.Message}");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    public static void VerPlazas()
    {
        Console.WriteLine("\n--- PLAZAS DISPONIBLES ---");
        try
        {
            var plazas = PlazaRepository.CargarPlazas();
            foreach (var plaza in plazas)
            {
                plaza.MostrarInformacion();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al cargar plazas: {e.Message}");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    public static void HacerReserva(Sesion sesion)
    {
        Console.WriteLine("\n--- HACER RESERVA ---");
        try
        {
            // Mostrar plazas disponibles
            var plazas = PlazaRepository.CargarPlazas();
            Console.WriteLine("Plazas disponibles:");
            for (int i = 0; i < plazas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {plazas[i].Tipo} - {plazas[i].Precio:C} (Disponibles: {plazas[i].CantidadDisponible})");
            }

            Console.Write("Selecciona una plaza (número): ");
            if (int.TryParse(Console.ReadLine(), out int plazaIndex) && plazaIndex > 0 && plazaIndex <= plazas.Count)
            {
                var plazaSeleccionada = plazas[plazaIndex - 1];
                
                if (plazaSeleccionada.CantidadDisponible > 0)
                {
                    // Crear reserva
                    var reservas = ReservaRepository.CargarReservas();
                    var nuevaReserva = new Reserva(reservas.Count + 1, sesion.UsuarioActivo!.Id, plazaSeleccionada.Id);
                    
                    // Actualizar stock de la plaza
                    plazaSeleccionada.CantidadDisponible--;
                    
                    // Guardar cambios
                    reservas.Add(nuevaReserva);
                    ReservaRepository.GuardarReservas(reservas);
                    PlazaRepository.GuardarPlazas(plazas);
                    
                    Console.WriteLine($"¡Reserva realizada con éxito! ID: {nuevaReserva.Id}");
                }
                else
                {
                    Console.WriteLine("No hay plazas disponibles de este tipo.");
                }
            }
            else
            {
                Console.WriteLine("Selección inválida.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al hacer reserva: {e.Message}");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    public static void CancelarReserva(Sesion sesion)
    {
        Console.WriteLine("\n--- CANCELAR RESERVA ---");
        try
        {
            var reservas = ReservaRepository.CargarReservas();
            var misReservas = reservas.Where(r => r.UsuarioId == sesion.UsuarioActivo?.Id).ToList();
            
            if (misReservas.Any())
            {
                Console.WriteLine("Tus reservas:");
                for (int i = 0; i < misReservas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Reserva {misReservas[i].Id} - Plaza {misReservas[i].PlazaId}");
                }
                
                Console.Write("Selecciona una reserva para cancelar (número): ");
                if (int.TryParse(Console.ReadLine(), out int reservaIndex) && reservaIndex > 0 && reservaIndex <= misReservas.Count)
                {
                    var reservaCancelar = misReservas[reservaIndex - 1];
                    
                    // Devolver stock a la plaza
                    var plazas = PlazaRepository.CargarPlazas();
                    var plaza = plazas.FirstOrDefault(p => p.Id == reservaCancelar.PlazaId);
                    if (plaza != null)
                    {
                        plaza.CantidadDisponible++;
                    }
                    
                    // Eliminar reserva
                    reservas.Remove(reservaCancelar);
                    
                    // Guardar cambios
                    ReservaRepository.GuardarReservas(reservas);
                    PlazaRepository.GuardarPlazas(plazas);
                    
                    Console.WriteLine("¡Reserva cancelada con éxito!");
                }
                else
                {
                    Console.WriteLine("Selección inválida.");
                }
            }
            else
            {
                Console.WriteLine("No tienes reservas para cancelar.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al cancelar reserva: {e.Message}");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    public static void RegistrarVehiculo(Sesion sesion)
    {
        Console.WriteLine("\n--- REGISTRAR VEHÍCULO ---");
        Console.Write("Marca: ");
        string marca = Console.ReadLine() ?? "";
        Console.Write("Matrícula: ");
        string matricula = Console.ReadLine() ?? "";
        
        try
        {
            var vehiculos = VehiculoRepository.CargarVehiculos();
            var nuevoVehiculo = new Vehiculo(vehiculos.Count + 1, marca, matricula);
            vehiculos.Add(nuevoVehiculo);
            VehiculoRepository.GuardarVehiculos(vehiculos);
            Console.WriteLine("¡Vehículo registrado con éxito!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al registrar vehículo: {e.Message}");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }
}
