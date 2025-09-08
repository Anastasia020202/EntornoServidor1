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
        InicializarNextIds();
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

    private static void InicializarNextIds()
    {
        // Inicializar nextId para Usuario (Cliente y Admin)
        var clientes = ClienteRepository.CargarClientes();
        var admins = AdminRepository.CargarAdmin();
        var maxUsuarioId = 0;
        if (clientes.Any()) maxUsuarioId = Math.Max(maxUsuarioId, clientes.Max(c => c.Id));
        if (admins.Any()) maxUsuarioId = Math.Max(maxUsuarioId, admins.Max(a => a.Id));
        Usuario.SetNextId(maxUsuarioId + 1);

        // Inicializar nextId para Vehiculo
        var vehiculos = VehiculoRepository.CargarVehiculos();
        var maxVehiculoId = vehiculos.Any() ? vehiculos.Max(v => v.Id) : 0;
        Vehiculo.SetNextId(maxVehiculoId + 1);

        // Inicializar nextId para Reserva
        var reservas = ReservaRepository.CargarReservas();
        var maxReservaId = reservas.Any() ? reservas.Max(r => r.Id) : 0;
        Reserva.SetNextId(maxReservaId + 1);

        // Inicializar nextId para Plaza (hereda de Servicio)
        var plazas = PlazaRepository.CargarPlazas();
        var maxPlazaId = plazas.Any() ? plazas.Max(p => p.Id) : 0;
        Servicio.SetNextId(maxPlazaId + 1);
    }
}
