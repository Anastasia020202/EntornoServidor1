namespace ParkingApp1.Models;

public abstract class Servicio
{
    private static int nextId = 0;

    public static void SetNextId(int value)
    {
        nextId = value;
    }
    
    public int Id { get; set; }
    public decimal Precio { get; set; }
    public int CantidadDisponible { get; set; }

    // Constructor sin parámetros para JSON
    public Servicio()
    {
        Precio = 0;
        CantidadDisponible = 0;
    }

    public Servicio(int id, decimal precio, int cantidadDisponible)
    {
        Id = id;
        Precio = precio;
        CantidadDisponible = cantidadDisponible;
    }

    // Constructor para la creación de nuevo servicio
    public Servicio(decimal precio, int cantidadDisponible)
    {
        Id = ++nextId;
        Precio = precio;
        CantidadDisponible = cantidadDisponible;
    }
}
