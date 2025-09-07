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
        Console.WriteLine("2. Iniciar sesión");
        Console.WriteLine("3. Registrarse");
        Console.WriteLine("4. Salir");
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
            var cliente = new Cliente(0, nombre, correo);
            var clientes = ClienteRepository.CargarClientes();
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
