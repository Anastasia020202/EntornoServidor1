namespace ParkingApp1.Models;

public abstract class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public DateTime FechaCreacion { get; set; }

    public Usuario(int id, string nombre, string email)
    {
        Id = id;
        Nombre = nombre;
        Email = email;
        FechaCreacion = DateTime.Now;
    }

    public virtual void MostrarInfo()
    {
        Console.WriteLine($"Usuario ID: {Id}, Nombre: {Nombre}, Email: {Email}");
        Console.WriteLine($"Fecha de creación: {FechaCreacion:dd/MM/yyyy}");
    }

    public abstract string ObtenerTipoUsuario();
}
