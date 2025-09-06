namespace ParkingApp1.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public Usuario(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"Usuario ID: {Id}, Nombre: {Nombre}");
    }
}
