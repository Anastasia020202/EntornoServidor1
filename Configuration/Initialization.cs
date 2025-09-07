using ParkingApp1.Models;
using ParkingApp1.Repositories;

namespace ParkingApp1.Configuration;

public static class Initialization
{
    public static void TodasInicializaciones()
    {
        InicializarPlazas();
        InicializarAdmin();
        InicializarClientes();
        InicializarVehiculos();
        InicializarReservas();
    }

    private static void InicializarPlazas()
    {
        var plazas = PlazaRepository.CargarPlazas();
        if (!plazas.Any())
        {
            plazas = new List<Plaza>
            {
                new Plaza(1, 2.50m, 10, "Normal"),
                new Plaza(2, 5.00m, 5, "Premium"),
                new Plaza(3, 1.50m, 8, "Moto")
            };
            PlazaRepository.GuardarPlazas(plazas);
        }
    }

    private static void InicializarAdmin()
    {
        var admins = AdminRepository.CargarAdmin();
        if (!admins.Any())
        {
            admins = new List<Admin>
            {
                new Admin(1, "admin@parking.com", "admin123", "Supervisor")
            };
            AdminRepository.GuardarAdmin(admins);
        }
    }

    private static void InicializarClientes()
    {
        var clientes = ClienteRepository.CargarClientes();
        if (!clientes.Any())
        {
            clientes = new List<Cliente>();
            ClienteRepository.GuardarClientes(clientes);
        }
    }

    private static void InicializarVehiculos()
    {
        var vehiculos = VehiculoRepository.CargarVehiculos();
        if (!vehiculos.Any())
        {
            vehiculos = new List<Vehiculo>();
            VehiculoRepository.GuardarVehiculos(vehiculos);
        }
    }

    private static void InicializarReservas()
    {
        var reservas = ReservaRepository.CargarReservas();
        if (!reservas.Any())
        {
            reservas = new List<Reserva>();
            ReservaRepository.GuardarReservas(reservas);
        }
    }
}
