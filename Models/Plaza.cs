namespace ParkingApp1.Models;

public class Plaza : Servicio
{
    public string Tipo { get; set; }

    // Constructor sin parámetros para JSON
    public Plaza() : base()
    {
        Tipo = "";
    }

    public Plaza(int id, decimal precio, int cantidadDisponible, string tipo) : base(id, precio, cantidadDisponible)
    {
        Tipo = tipo;
    }

    // Constructor para la creación de nueva plaza
    public Plaza(decimal precio, int cantidadDisponible, string tipo) : base(precio, cantidadDisponible)
    {
        Tipo = tipo;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Plaza {Id}: {Tipo} - {Precio:C} (Disponibles: {CantidadDisponible})");
    }
}
