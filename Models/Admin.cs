namespace ParkingApp1.Models;

public class Admin : Usuario
{
    public string Rol { get; set; }

    // Constructor sin parámetros para JSON
    public Admin() : base()
    {
        Rol = "";
    }

    public Admin(int id, string nombre, string email, string rol) : base(id, nombre, email)
    {
        Rol = rol;
    }

    public override string ObtenerTipoUsuario()
    {
        return "Administrador";
    }

    public override void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine($"Tipo: {ObtenerTipoUsuario()}");
        Console.WriteLine($"Rol: {Rol}");
    }
}
