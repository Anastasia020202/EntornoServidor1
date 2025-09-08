using ParkingApp1.Models;
using ParkingApp1.Repositories;

namespace ParkingApp1.ConsoleUI;

public class MenuAdmin
{
    public static void MostrarMenu()
    {
        Console.WriteLine("\n=== MENÚ ADMINISTRADOR ===");
        Console.WriteLine("1. Ver todas las plazas");
        Console.WriteLine("2. Añadir nueva plaza");
        Console.WriteLine("3. Editar plaza existente");
        Console.WriteLine("");
        Console.WriteLine("==========================");
        Console.WriteLine("");
        Console.WriteLine("4. Ver todas las reservas");
        Console.WriteLine("5. Eliminar reserva");
        Console.WriteLine("");
        Console.WriteLine("==========================");
        Console.WriteLine("");
        Console.WriteLine("6. Ver clientes registrados");
        Console.WriteLine("7. Registrar nuevo cliente");
        Console.WriteLine("8. Eliminar cliente");
        Console.WriteLine("9. Añadir vehículo a cliente");
        Console.WriteLine("10. Eliminar vehículo");
        Console.WriteLine("");
        Console.WriteLine("11. Cerrar sesión");
        Console.WriteLine("==========================");
        Console.Write("Selecciona una opción: ");
    }

    public static void VerTodasLasPlazas()
    {
        Console.WriteLine("\n--- TODAS LAS PLAZAS ---");
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

    public static void AñadirNuevaPlaza()
    {
        Console.WriteLine("\n--- AÑADIR NUEVA PLAZA ---");
        Console.Write("Tipo de plaza: ");
        string tipo = Console.ReadLine() ?? "";
        Console.Write("Precio: ");
        string precioInput = Console.ReadLine() ?? "";
        if (decimal.TryParse(precioInput.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal precio))
        {
            Console.Write("Cantidad disponible: ");
            if (int.TryParse(Console.ReadLine(), out int cantidad))
            {
                try
                {
                    var plazas = PlazaRepository.CargarPlazas();
                    
                    var nuevaPlaza = new Plaza(precio, cantidad, tipo);
                    plazas.Add(nuevaPlaza);
                    PlazaRepository.GuardarPlazas(plazas);
                    Console.WriteLine("¡Plaza añadida con éxito!");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error al añadir plaza: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine("Cantidad inválida.");
            }
        }
        else
        {
            Console.WriteLine("Precio inválido.");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    public static void EditarPlazaExistente()
    {
        Console.WriteLine("\n--- EDITAR PLAZA EXISTENTE ---");
        try
        {
            var plazas = PlazaRepository.CargarPlazas();
            Console.WriteLine("Plazas disponibles:");
            for (int i = 0; i < plazas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {plazas[i].Tipo} - {plazas[i].Precio:C} (Disponibles: {plazas[i].CantidadDisponible})");
            }
            
            Console.Write("Selecciona una plaza para editar (número): ");
            if (int.TryParse(Console.ReadLine(), out int plazaIndex) && plazaIndex > 0 && plazaIndex <= plazas.Count)
            {
                var plazaEditar = plazas[plazaIndex - 1];
                
                Console.Write($"Nuevo precio (actual: {plazaEditar.Precio:C}): ");
                string precioInput = Console.ReadLine() ?? "";
                if (decimal.TryParse(precioInput.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal nuevoPrecio))
                {
                    plazaEditar.Precio = nuevoPrecio;
                }
                
                Console.Write($"Nueva cantidad disponible (actual: {plazaEditar.CantidadDisponible}): ");
                if (int.TryParse(Console.ReadLine(), out int nuevaCantidad))
                {
                    plazaEditar.CantidadDisponible = nuevaCantidad;
                }
                
                PlazaRepository.GuardarPlazas(plazas);
                Console.WriteLine("¡Plaza editada con éxito!");
            }
            else
            {
                Console.WriteLine("Selección inválida.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al editar plaza: {e.Message}");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    public static void VerTodasLasReservas()
    {
        Console.WriteLine("\n--- TODAS LAS RESERVAS ---");
        try
        {
            var reservas = ReservaRepository.CargarReservas();
            if (reservas.Any())
            {
                foreach (var reserva in reservas)
                {
                    reserva.MostrarDetalles();
                }
            }
            else
            {
                Console.WriteLine("No hay reservas en el sistema.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al cargar reservas: {e.Message}");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    public static void VerClientesRegistrados()
    {
        Console.WriteLine("\n--- CLIENTES REGISTRADOS ---");
        try
        {
            var clientes = ClienteRepository.CargarClientes();
            if (clientes.Any())
            {
                foreach (var cliente in clientes)
                {
                    cliente.MostrarInfo();
                }
            }
            else
            {
                Console.WriteLine("No hay clientes registrados.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al cargar clientes: {e.Message}");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    public static void EliminarCliente()
    {
        Console.WriteLine("\n--- ELIMINAR CLIENTE ---");
        try
        {
            var clientes = ClienteRepository.CargarClientes();
            if (clientes.Any())
            {
                Console.WriteLine("Clientes disponibles:");
                for (int i = 0; i < clientes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {clientes[i].Nombre} ({clientes[i].Email})");
                }
                
                Console.Write("Selecciona un cliente para eliminar (número): ");
                if (int.TryParse(Console.ReadLine(), out int clienteIndex) && clienteIndex > 0 && clienteIndex <= clientes.Count)
                {
                    var clienteEliminar = clientes[clienteIndex - 1];
                    clientes.Remove(clienteEliminar);
                    ClienteRepository.GuardarClientes(clientes);
                    Console.WriteLine("¡Cliente eliminado con éxito!");
                }
                else
                {
                    Console.WriteLine("Selección inválida.");
                }
            }
            else
            {
                Console.WriteLine("No hay clientes para eliminar.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al eliminar cliente: {e.Message}");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    public static void RegistrarNuevoCliente()
    {
        Console.WriteLine("\n--- REGISTRAR NUEVO CLIENTE ---");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Correo: ");
        string correo = Console.ReadLine() ?? "";
        Console.Write("Contraseña: ");
        string contrasena = Console.ReadLine() ?? "";

        try
        {
            // Verificar si el correo ya existe
            var clientes = ClienteRepository.CargarClientes();
            var admins = AdminRepository.CargarAdmin();
            
            if (clientes.Any(c => c.Email == correo) || admins.Any(a => a.Email == correo))
            {
                Console.WriteLine("Este correo ya está registrado. Por favor, usa otro correo.");
                return;
            }

            var cliente = new Cliente(nombre, correo);
            clientes.Add(cliente);
            ClienteRepository.GuardarClientes(clientes);
            Console.WriteLine("¡Cliente registrado con éxito!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al registrar cliente: {e.Message}");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    public static void AñadirVehiculoACliente()
    {
        Console.WriteLine("\n--- AÑADIR VEHÍCULO A CLIENTE ---");
        try
        {
            var clientes = ClienteRepository.CargarClientes();
            if (!clientes.Any())
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }

            Console.WriteLine("Clientes disponibles:");
            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {clientes[i].Nombre} ({clientes[i].Email})");
            }
            
            Console.Write("Selecciona un cliente (número): ");
            if (int.TryParse(Console.ReadLine(), out int clienteIndex) && clienteIndex > 0 && clienteIndex <= clientes.Count)
            {
                var clienteSeleccionado = clientes[clienteIndex - 1];
                
                Console.WriteLine("Tipo de vehículo:");
                Console.WriteLine("1. Coche");
                Console.WriteLine("2. Moto");
                Console.Write("Selecciona tipo (1-2): ");
                
                string tipoVehiculo = "";
                if (int.TryParse(Console.ReadLine(), out int tipoIndex))
                {
                    tipoVehiculo = tipoIndex switch
                    {
                        1 => "Coche",
                        2 => "Moto",
                        _ => "Coche"
                    };
                }
                else
                {
                    tipoVehiculo = "Coche";
                }
                
                Console.Write("Marca: ");
                string marca = Console.ReadLine() ?? "";
                Console.Write("Modelo: ");
                string modelo = Console.ReadLine() ?? "";
                Console.Write("Color: ");
                string color = Console.ReadLine() ?? "";
                Console.Write("Matrícula: ");
                string matricula = Console.ReadLine() ?? "";

                var vehiculos = VehiculoRepository.CargarVehiculos();
                
                var nuevoVehiculo = new Vehiculo(marca, modelo, color, matricula, tipoVehiculo, clienteSeleccionado.Id);
                vehiculos.Add(nuevoVehiculo);
                VehiculoRepository.GuardarVehiculos(vehiculos);
                Console.WriteLine($"¡Vehículo añadido con éxito al cliente {clienteSeleccionado.Nombre}!");
            }
            else
            {
                Console.WriteLine("Selección inválida.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al añadir vehículo: {e.Message}");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    public static void EliminarVehiculo()
    {
        Console.WriteLine("\n--- ELIMINAR VEHÍCULO ---");
        try
        {
            var vehiculos = VehiculoRepository.CargarVehiculos();
            if (!vehiculos.Any())
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }

            Console.WriteLine("Vehículos disponibles:");
            for (int i = 0; i < vehiculos.Count; i++)
            {
                var vehiculo = vehiculos[i];
                Console.WriteLine($"{i + 1}. {vehiculo.Marca} {vehiculo.Modelo} ({vehiculo.Matricula}) - Tipo: {vehiculo.TipoVehiculo}");
            }
            
            Console.Write("Selecciona un vehículo para eliminar (número): ");
            if (int.TryParse(Console.ReadLine(), out int vehiculoIndex) && vehiculoIndex > 0 && vehiculoIndex <= vehiculos.Count)
            {
                var vehiculoEliminar = vehiculos[vehiculoIndex - 1];
                vehiculos.Remove(vehiculoEliminar);
                VehiculoRepository.GuardarVehiculos(vehiculos);
                Console.WriteLine("¡Vehículo eliminado con éxito!");
            }
            else
            {
                Console.WriteLine("Selección inválida.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al eliminar vehículo: {e.Message}");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    public static void EliminarReserva()
    {
        Console.WriteLine("\n--- ELIMINAR RESERVA ---");
        try
        {
            var reservas = ReservaRepository.CargarReservas();
            if (!reservas.Any())
            {
                Console.WriteLine("No hay reservas en el sistema.");
                return;
            }

            Console.WriteLine("Reservas disponibles:");
            for (int i = 0; i < reservas.Count; i++)
            {
                var reserva = reservas[i];
                Console.WriteLine($"{i + 1}. ID: {reserva.Id} - Usuario ID: {reserva.UsuarioId} - Plaza ID: {reserva.PlazaId} - Horas: {reserva.Horas}");
            }
            
            Console.Write("Selecciona una reserva para eliminar (número): ");
            if (int.TryParse(Console.ReadLine(), out int reservaIndex) && reservaIndex > 0 && reservaIndex <= reservas.Count)
            {
                var reservaEliminar = reservas[reservaIndex - 1];
                
                // Restaurar stock de la plaza
                var plazas = PlazaRepository.CargarPlazas();
                var plaza = plazas.FirstOrDefault(p => p.Id == reservaEliminar.PlazaId);
                if (plaza != null)
                {
                    plaza.CantidadDisponible++;
                    PlazaRepository.GuardarPlazas(plazas);
                }
                
                reservas.Remove(reservaEliminar);
                ReservaRepository.GuardarReservas(reservas);
                Console.WriteLine("¡Reserva eliminada con éxito!");
            }
            else
            {
                Console.WriteLine("Selección inválida.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al eliminar reserva: {e.Message}");
        }
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }
}
