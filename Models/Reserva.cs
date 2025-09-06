namespace ParkingApp1.Models;

public class Reserva
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int PlazaId { get; set; }

    public Reserva(int id, int usuarioId, int plazaId)
    {
        Id = id;
        UsuarioId = usuarioId;
        PlazaId = plazaId;
    }

    public void MostrarDetalles()
    {
        Console.WriteLine($"Reserva {Id}: Usuario {UsuarioId} -> Plaza {PlazaId}");
    }
}
