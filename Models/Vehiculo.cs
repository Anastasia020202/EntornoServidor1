namespace ParkingApp1.Models;

public class Vehiculo
{
    public int Id { get; set; }
    public string Marca { get; set; }
    public string Matricula { get; set; }

    public Vehiculo(int id, string marca, string matricula)
    {
        Id = id;
        Marca = marca;
        Matricula = matricula;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Vehículo {Id}: {Marca} - {Matricula}");
    }
}
