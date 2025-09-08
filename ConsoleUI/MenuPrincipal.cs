using ParkingApp1.Models;
using ParkingApp1.Repositories;
using ParkingApp1.Services;

namespace ParkingApp1.ConsoleUI;

public class MenuPrincipal
{
    public static void MostrarMenu()
    {
        Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Ver plazas disponibles");
        Console.WriteLine("2. Buscar plazas");
        Console.WriteLine("3. Iniciar sesión");
        Console.WriteLine("4. Registrarse");
        Console.WriteLine("5. Salir");
        Console.WriteLine("========================");
        Console.Write("Selecciona una opción: ");
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

    public static Sesion IniciarSesion()
    {
        Console.WriteLine("\n--- INICIAR SESIÓN ---");
        Console.Write("Correo: ");
        string correo = Console.ReadLine() ?? "";
        Console.Write("Contraseña: ");
        string contrasena = Console.ReadLine() ?? "";

        var sesion = new Sesion();
        if (sesion.IniciarSesion(correo, contrasena))
        {
            Console.WriteLine($"¡Bienvenido, {sesion.UsuarioActivo?.Nombre}!");
            return sesion;
        }
        else
        {
            Console.WriteLine("Credenciales incorrectas.");
            return sesion;
        }
    }

    public static void BuscarPlazas()
    {
        Console.WriteLine("\n--- BUSCAR PLAZAS ---");
        Console.Write("Introduce el tipo de plaza (Estándar, Premium, Moto): ");
        string tipo = Console.ReadLine() ?? "";
        
        try
        {
            var plazas = PlazaRepository.CargarPlazas();
            var resultados = plazas.Where(p => p.Tipo.ToLower().Contains(tipo.ToLower())).ToList();
            
            if (resultados.Any())
            {
                Console.WriteLine($"\n--- RESULTADOS DE BÚSQUEDA ({resultados.Count} encontradas) ---");
                foreach (var plaza in resultados)
                {
                    plaza.MostrarInformacion();
                }
            }
            else
            {
                Console.WriteLine("No se encontraron plazas con el tipo especificado.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error en la búsqueda: {e.Message}");
        }
        
        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    public static void Registrarse()
    {
        Console.WriteLine("\n--- REGISTRARSE ---");
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
            Console.WriteLine("¡Registrado con éxito!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al registrarse: {e.Message}");
        }
    }
}
