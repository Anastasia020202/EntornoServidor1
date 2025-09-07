namespace ParkingApp1.Models;

public class Plaza : Servicio
{
    public string Tipo { get; set; }

    public Plaza(int id, decimal precio, int cantidadDisponible, string tipo) : base(id, precio, cantidadDisponible)
    {
        Tipo = tipo;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Plaza {Id}: {Tipo} - {Precio:C} (Disponibles: {CantidadDisponible})");
    }
}
