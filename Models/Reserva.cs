namespace ParkingApp1.Models;

public class Reserva
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int PlazaId { get; set; }
    public int VehiculoId { get; set; }
    public DateTime Fecha { get; set; }
    public int Horas { get; set; }
    public decimal Importe { get; set; }

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

    public void MostrarDetalles()
    {
        Console.WriteLine($"Reserva {Id}: Usuario {UsuarioId} -> Plaza {PlazaId}");
        Console.WriteLine($"Vehículo: {VehiculoId} | Duración: {Horas} horas");
        Console.WriteLine($"Fecha: {Fecha:dd/MM/yyyy HH:mm} | Importe: {Importe:C}");
    }
}
