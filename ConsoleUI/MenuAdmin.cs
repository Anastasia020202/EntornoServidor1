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
        Console.WriteLine("4. Ver todas las reservas");
        Console.WriteLine("5. Ver clientes registrados");
        Console.WriteLine("6. Eliminar cliente");
        Console.WriteLine("7. Cerrar sesión");
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
        if (decimal.TryParse(Console.ReadLine(), out decimal precio))
        {
            Console.Write("Cantidad disponible: ");
            if (int.TryParse(Console.ReadLine(), out int cantidad))
            {
                try
                {
                    var plazas = PlazaRepository.CargarPlazas();
                    var nuevaPlaza = new Plaza(plazas.Count + 1, precio, cantidad, tipo);
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
                if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio))
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
}
