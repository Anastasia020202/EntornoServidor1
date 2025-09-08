namespace ParkingApp1.Models;

public class Reserva
{
    private static int nextId = 0;

    public static void SetNextId(int value)
    {
        nextId = value;
    }
    
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int PlazaId { get; set; }
    public int VehiculoId { get; set; }
    public DateTime Fecha { get; set; }
    public int Horas { get; set; }
    public decimal Importe { get; set; }

    // Constructor sin parámetros para JSON
    public Reserva()
    {
        UsuarioId = 0;
        PlazaId = 0;
        VehiculoId = 0;
        Fecha = DateTime.Now;
        Horas = 0;
        Importe = 0;
    }

    public Reserva(int id, int usuarioId, int plazaId, int vehiculoId, int horas, decimal importe)
    {
        Id = id;
        UsuarioId = usuarioId;
        PlazaId = plazaId;
        VehiculoId = vehiculoId;
        Fecha = DateTime.Now;
        Horas = horas;
        Importe = importe;
    }

    // Constructor para la creación de nueva reserva
    public Reserva(int usuarioId, int plazaId, int vehiculoId, int horas, decimal importe)
    {
        Id = ++nextId;
        UsuarioId = usuarioId;
        PlazaId = plazaId;
        VehiculoId = vehiculoId;
        Fecha = DateTime.Now;
        Horas = horas;
        Importe = importe;
    }

    public void MostrarDetalles()
    {
        Console.WriteLine($"Reserva {Id}: Usuario {UsuarioId} -> Plaza {PlazaId}");
        Console.WriteLine($"Vehículo: {VehiculoId} | Duración: {Horas} horas");
        Console.WriteLine($"Fecha: {Fecha:dd/MM/yyyy HH:mm} | Importe: {Importe:C}");
    }
}
