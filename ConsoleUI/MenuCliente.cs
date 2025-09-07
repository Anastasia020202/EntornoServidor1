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
            // 1. Mostrar plazas disponibles
            var plazas = PlazaRepository.CargarPlazas();
            var plazasDisponibles = plazas.Where(p => p.CantidadDisponible > 0).ToList();
            
            if (!plazasDisponibles.Any())
            {
                Console.WriteLine("No hay plazas disponibles para reservar.");
                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            Console.WriteLine("Plazas disponibles:");
            foreach (var plaza in plazasDisponibles)
            {
                plaza.MostrarInformacion();
            }
            
            // 2. Seleccionar plaza
            Console.Write("\nSelecciona el ID de la plaza: ");
            if (!int.TryParse(Console.ReadLine(), out int plazaId))
            {
                Console.WriteLine("ID de plaza inválido.");
                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            var plazaSeleccionada = plazasDisponibles.FirstOrDefault(p => p.Id == plazaId);
            if (plazaSeleccionada == null)
            {
                Console.WriteLine("Plaza no encontrada o no disponible.");
                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            // 3. Seleccionar vehículo
            var vehiculos = VehiculoRepository.CargarVehiculos();
            var misVehiculos = vehiculos.Where(v => v.UsuarioId == sesion.UsuarioActivo!.Id && v.Activo).ToList();
            
            if (!misVehiculos.Any())
            {
                Console.WriteLine("No tienes vehículos registrados. Debes registrar un vehículo primero.");
                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            Console.WriteLine("\nTus vehículos:");
            foreach (var vehiculo in misVehiculos)
            {
                vehiculo.MostrarInformacion();
            }
            
            Console.Write("\nSelecciona el ID del vehículo: ");
            if (!int.TryParse(Console.ReadLine(), out int vehiculoId))
            {
                Console.WriteLine("ID de vehículo inválido.");
                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            var vehiculoSeleccionado = misVehiculos.FirstOrDefault(v => v.Id == vehiculoId);
            if (vehiculoSeleccionado == null)
            {
                Console.WriteLine("Vehículo no encontrado.");
                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            // 4. Pedir duración
            Console.Write("\n¿Cuántas horas quieres reservar? ");
            if (!int.TryParse(Console.ReadLine(), out int horas) || horas <= 0)
            {
                Console.WriteLine("Número de horas inválido.");
                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            // 5. Calcular importe
            decimal importe = plazaSeleccionada.Precio * horas;
            
            // 6. Confirmar reserva
            Console.WriteLine($"\nResumen de la reserva:");
            Console.WriteLine($"Plaza: {plazaSeleccionada.Tipo} - {plazaSeleccionada.Precio:C}/hora");
            Console.WriteLine($"Vehículo: {vehiculoSeleccionado.Marca} {vehiculoSeleccionado.Modelo}");
            Console.WriteLine($"Duración: {horas} horas");
            Console.WriteLine($"Importe total: {importe:C}");
            
            Console.Write("\n¿Confirmar reserva? (s/n): ");
            string? confirmacion = Console.ReadLine()?.ToLower();
            
            if (confirmacion == "s" || confirmacion == "si")
            {
                // 7. Crear reserva
                var reservas = ReservaRepository.CargarReservas();
                var nuevaReserva = new Reserva(reservas.Count + 1, sesion.UsuarioActivo!.Id, plazaSeleccionada.Id, vehiculoSeleccionado.Id, horas, importe);
                
                // 8. Actualizar stock de la plaza
                plazaSeleccionada.CantidadDisponible--;
                
                // 9. Guardar cambios
                reservas.Add(nuevaReserva);
                ReservaRepository.GuardarReservas(reservas);
                PlazaRepository.GuardarPlazas(plazas);
                
                // 10. Actualizar historial del cliente
                var clientes = ClienteRepository.CargarClientes();
                var cliente = clientes.FirstOrDefault(c => c.Id == sesion.UsuarioActivo!.Id);
                if (cliente != null)
                {
                    cliente.HistoricoReservas.Add(nuevaReserva);
                    ClienteRepository.GuardarClientes(clientes);
                }
                
                Console.WriteLine($"\n¡Reserva realizada con éxito!");
                Console.WriteLine($"ID de reserva: {nuevaReserva.Id}");
                Console.WriteLine($"Importe: {nuevaReserva.Importe:C}");
            }
            else
            {
                Console.WriteLine("Reserva cancelada.");
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
            // 1. Obtener reservas del cliente
            var clientes = ClienteRepository.CargarClientes();
            var cliente = clientes.FirstOrDefault(c => c.Id == sesion.UsuarioActivo!.Id);
            
            if (cliente == null || !cliente.HistoricoReservas.Any())
            {
                Console.WriteLine("No tienes reservas para cancelar.");
                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            var misReservas = cliente.HistoricoReservas;
            
            // 2. Mostrar reservas del cliente
            Console.WriteLine("Tus reservas:");
            foreach (var reserva in misReservas)
            {
                Console.WriteLine($"({reserva.Id}) - {reserva.Fecha:dd/MM/yyyy HH:mm} - {reserva.Importe:C}");
            }
            
            // 3. Seleccionar reserva a cancelar
            Console.Write("\nSelecciona el ID de la reserva a cancelar: ");
            if (!int.TryParse(Console.ReadLine(), out int reservaId))
            {
                Console.WriteLine("ID de reserva inválido.");
                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            var reservaACancelar = misReservas.FirstOrDefault(r => r.Id == reservaId);
            if (reservaACancelar == null)
            {
                Console.WriteLine("Reserva no encontrada.");
                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            // 4. Confirmar cancelación
            Console.WriteLine($"\nResumen de la reserva a cancelar:");
            Console.WriteLine($"ID: {reservaACancelar.Id}");
            Console.WriteLine($"Fecha: {reservaACancelar.Fecha:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Importe: {reservaACancelar.Importe:C}");
            
            Console.Write("\n¿Confirmar cancelación? (s/n): ");
            string? confirmacion = Console.ReadLine()?.ToLower();
            
            if (confirmacion == "s" || confirmacion == "si")
            {
                // 5. Eliminar la reserva de la lista global
                var reservas = ReservaRepository.CargarReservas();
                reservas.RemoveAll(r => r.Id == reservaACancelar.Id);
                ReservaRepository.GuardarReservas(reservas);
                
                // 6. Restaurar plaza disponible
                var plazas = PlazaRepository.CargarPlazas();
                var plazaReservada = plazas.FirstOrDefault(p => p.Id == reservaACancelar.PlazaId);
                if (plazaReservada != null)
                {
                    plazaReservada.CantidadDisponible++;
                    PlazaRepository.GuardarPlazas(plazas);
                }
                
                // 7. Actualizar historial del cliente
                cliente.HistoricoReservas.RemoveAll(r => r.Id == reservaACancelar.Id);
                ClienteRepository.GuardarClientes(clientes);
                
                Console.WriteLine($"\n¡Reserva cancelada con éxito!");
                Console.WriteLine($"ID de reserva cancelada: {reservaACancelar.Id}");
            }
            else
            {
                Console.WriteLine("Cancelación abortada.");
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
        Console.Write("Modelo: ");
        string modelo = Console.ReadLine() ?? "";
        Console.Write("Color: ");
        string color = Console.ReadLine() ?? "";
        Console.Write("Matrícula: ");
        string matricula = Console.ReadLine() ?? "";
        
        try
        {
            var vehiculos = VehiculoRepository.CargarVehiculos();
            var nuevoVehiculo = new Vehiculo(vehiculos.Count + 1, marca, modelo, color, matricula, sesion.UsuarioActivo!.Id);
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
