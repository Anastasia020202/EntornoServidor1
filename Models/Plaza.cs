namespace ParkingApp1.Models;

public class Plaza : Servicio
{
    public string Tipo { get; set; }

    public Plaza(int id, decimal precio, string tipo) : base(id, precio)
    {
        Tipo = tipo;
    }
}
