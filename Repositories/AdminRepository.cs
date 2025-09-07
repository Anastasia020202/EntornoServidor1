using ParkingApp1.Models;
using ParkingApp1.Utilities;

namespace ParkingApp1.Repositories;

public static class AdminRepository
{
    public static string Ruta = "data/admin.json";

    public static List<Admin> CargarAdmin()
    {
        try
        {
            return JsonUtility.CargarJson<List<Admin>>(Ruta);
        }
        catch (FileNotFoundException)
        {
            return new List<Admin>();
        }
    }

    public static void GuardarAdmin(List<Admin> admins)
    {
        JsonUtility.GuardarJson(Ruta, admins);
    }
}
