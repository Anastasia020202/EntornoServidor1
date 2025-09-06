namespace ParkingApp1.Models;

public abstract class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }

    public Usuario(int id, string nombre, string email)
    {
        Id = id;
        Nombre = nombre;
        Email = email;
    }

    public virtual void MostrarInfo()
    {
        Console.WriteLine($"Usuario ID: {Id}, Nombre: {Nombre}, Email: {Email}");
    }

    public abstract string ObtenerTipoUsuario();
}
