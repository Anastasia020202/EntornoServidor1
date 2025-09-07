namespace ParkingApp1.Models;

public class Reserva
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int PlazaId { get; set; }
    public DateTime Fecha { get; set; }

    public Reserva(int id, int usuarioId, int plazaId)
    {
        Id = id;
        UsuarioId = usuarioId;
        PlazaId = plazaId;
        Fecha = DateTime.Now;
    }

    public void MostrarDetalles()
    {
        Console.WriteLine($"Reserva {Id}: Usuario {UsuarioId} -> Plaza {PlazaId}");
        Console.WriteLine($"Fecha: {Fecha:dd/MM/yyyy HH:mm}");
    }
}
