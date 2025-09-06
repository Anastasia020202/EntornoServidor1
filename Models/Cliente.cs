namespace ParkingApp1.Models;

public class Cliente : Usuario
{
    public DateTime FechaRegistro { get; set; }

    public Cliente(int id, string nombre, string email) : base(id, nombre, email)
    {
        FechaRegistro = DateTime.Now;
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
}
