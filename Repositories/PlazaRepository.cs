using ParkingApp1.Models;
using ParkingApp1.Utilities;

namespace ParkingApp1.Repositories;

public static class PlazaRepository
{
    public static string Ruta = "data/plaza.json";

    public static List<Plaza> CargarPlazas()
    {
        try
        {
            return JsonUtility.CargarJson<List<Plaza>>(Ruta);
        }
        catch (FileNotFoundException)
        {
            return new List<Plaza>();
        }
    }

    public static void GuardarPlazas(List<Plaza> plazas)
    {
        JsonUtility.GuardarJson(Ruta, plazas);
    }
}
