namespace ParkingApp1.Models;

public abstract class Usuario
{
    private static int nextId = 0;

    public static void SetNextId(int value)
    {
        nextId = value;
    }
    
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public DateTime FechaCreacion { get; set; }

    // Constructor sin parámetros para JSON
    public Usuario()
    {
        Nombre = "";
        Email = "";
        FechaCreacion = DateTime.Now;
    }

    public Usuario(int id, string nombre, string email)
    {
        Id = id;
        Nombre = nombre;
        Email = email;
        FechaCreacion = DateTime.Now;
    }

    // Constructor para la creación de nuevo usuario
    public Usuario(string nombre, string email)
    {
        Id = ++nextId;
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

    public bool CompararHash(string contrasena)
    {
        // Por ahora, comparación simple - acepta cualquier contraseña
        // En una implementación real, aquí se haría el hash de la contraseña
        return !string.IsNullOrEmpty(contrasena);
    }
}
