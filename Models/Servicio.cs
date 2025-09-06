namespace ParkingApp1.Models;

public abstract class Servicio
{
   public int Id { get; set; }
    public decimal Precio { get; set; }

    public Servicio(int id, decimal precio)
    {
        Id = id;
        Precio = precio;
    }
}
