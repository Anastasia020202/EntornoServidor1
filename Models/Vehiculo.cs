namespace ParkingApp1.Models;

public class Vehiculo
{
    private static int nextId = 0;

    public static void SetNextId(int value)
    {
        nextId = value;
    }
    
    public int Id { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Color { get; set; }
    public string Matricula { get; set; }
    public string TipoVehiculo { get; set; }
    public int UsuarioId { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaRegistro { get; set; }

    // Constructor sin parámetros para JSON
    public Vehiculo()
    {
        Marca = "";
        Modelo = "";
        Color = "";
        Matricula = "";
        TipoVehiculo = "";
        UsuarioId = 0;
        Activo = true;
        FechaRegistro = DateTime.Now;
    }

    public Vehiculo(int id, string marca, string modelo, string color, string matricula, string tipoVehiculo, int usuarioId)
    {
        Id = id;
        Marca = marca;
        Modelo = modelo;
        Color = color;
        Matricula = matricula;
        TipoVehiculo = tipoVehiculo;
        UsuarioId = usuarioId;
        Activo = true;
        FechaRegistro = DateTime.Now;
    }

    // Constructor para la creación de nuevo vehículo
    public Vehiculo(string marca, string modelo, string color, string matricula, string tipoVehiculo, int usuarioId)
    {
        Id = ++nextId;
        Marca = marca;
        Modelo = modelo;
        Color = color;
        Matricula = matricula;
        TipoVehiculo = tipoVehiculo;
        UsuarioId = usuarioId;
        Activo = true;
        FechaRegistro = DateTime.Now;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"ID {Id}: {Marca} {Modelo} ({Color}) - {Matricula} [{TipoVehiculo}]");
        Console.WriteLine($"Registrado: {FechaRegistro:dd/MM/yyyy}");
    }
}
