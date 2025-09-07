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
                if (sesion.EsAdmin)
                {
                    // Menú de administrador
                    while (true)
                    {
                        MenuAdmin.MostrarMenu();
                        if (int.TryParse(Console.ReadLine(), out int opcionAdmin))
                        {
                            switch (opcionAdmin)
                            {
                                case 1:
                                    MenuAdmin.VerTodasLasPlazas();
                                    break;
                                case 2:
                                    MenuAdmin.AñadirNuevaPlaza();
                                    break;
                                case 3:
                                    MenuAdmin.EditarPlazaExistente();
                                    break;
                                case 4:
                                    MenuAdmin.VerTodasLasReservas();
                                    break;
                                case 5:
                                    MenuAdmin.VerClientesRegistrados();
                                    break;
                                case 6:
                                    MenuAdmin.EliminarCliente();
                                    break;
                                case 7:
                                    sesion.CerrarSesion();
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida.");
                                    break;
                            }
                            if (opcionAdmin == 7) break;
                        }
                    }
                }
                else
                {
                    // Menú de cliente
                    while (true)
                    {
                        MenuCliente.MostrarMenu(sesion);
                        if (int.TryParse(Console.ReadLine(), out int opcionCliente))
                        {
                            switch (opcionCliente)
                            {
                                case 1:
                                    MenuCliente.VerMisReservas(sesion);
                                    break;
                                case 2:
                                    MenuCliente.VerPlazas();
                                    break;
                                case 3:
                                    MenuCliente.HacerReserva(sesion);
                                    break;
                                case 4:
                                    MenuCliente.CancelarReserva(sesion);
                                    break;
                                case 5:
                                    MenuCliente.RegistrarVehiculo(sesion);
                                    break;
                                case 6:
                                    sesion.CerrarSesion();
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida.");
                                    break;
                            }
                            if (opcionCliente == 6) break;
                        }
                    }
                }
            }
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
