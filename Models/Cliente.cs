namespace ParkingApp1.Models;

public class Cliente : Usuario
{
    public DateTime FechaRegistro { get; set; }
    public List<Reserva> HistoricoReservas { get; set; }

    public Cliente(int id, string nombre, string email) : base(id, nombre, email)
    {
        FechaRegistro = DateTime.Now;
        HistoricoReservas = new List<Reserva>();
    }

    public override string ObtenerTipoUsuario()
    {
        return "Cliente";
    }

    public override void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine($"Tipo: {ObtenerTipoUsuario()}");
        Console.WriteLine($"Fecha de registro: {FechaRegistro:dd/MM/yyyy}");
    }

    public void VerReservas()
    {
        if (HistoricoReservas.Any())
        {
            foreach (var reserva in HistoricoReservas)
            {
                reserva.MostrarDetalles();
            }
        }
        else
        {
            Console.WriteLine("No tienes reservas registradas.");
        }
    }
}
