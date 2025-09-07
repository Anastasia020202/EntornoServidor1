using ParkingApp1.Models;
using ParkingApp1.Utilities;

namespace ParkingApp1.Repositories;

public static class ClienteRepository
{
    public static string Ruta = "data/cliente.json";

    public static List<Cliente> CargarClientes()
    {
        try
        {
            return JsonUtility.CargarJson<List<Cliente>>(Ruta);
        }
        catch (FileNotFoundException)
        {
            return new List<Cliente>();
        }
    }

    public static void GuardarClientes(List<Cliente> clientes)
    {
        JsonUtility.GuardarJson(Ruta, clientes);
    }
}
