using ParkingApp1.Models;
using ParkingApp1.Repositories;

namespace ParkingApp1.Services;

public class Sesion
{
    public bool EstaActiva { get; set; }
    public Usuario? UsuarioActivo { get; set; }
    public bool EsAdmin { get; set; }

    public Sesion()
    {
        EstaActiva = false;
        UsuarioActivo = null;
        EsAdmin = false;
    }

    public bool IniciarSesion(string correo, string contrasena)
    {
        try
        {
            // Buscar en clientes
            var clientes = ClienteRepository.CargarClientes();
            var cliente = clientes.FirstOrDefault(c => c.Email == correo);
            
            if (cliente != null && cliente.CompararHash(contrasena))
            {
                UsuarioActivo = cliente;
                EsAdmin = false;
                EstaActiva = true;
                return true;
            }

            // Buscar en admins
            var admins = AdminRepository.CargarAdmin();
            var admin = admins.FirstOrDefault(a => a.Email == correo);
            
            if (admin != null && admin.CompararHash(contrasena))
            {
                UsuarioActivo = admin;
                EsAdmin = true;
                EstaActiva = true;
                return true;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void CerrarSesion()
    {
        EstaActiva = false;
        UsuarioActivo = null;
        EsAdmin = false;
    }
}
