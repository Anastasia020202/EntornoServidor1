using ParkingApp1.Models;
using ParkingApp1.Utilities;

namespace ParkingApp1.Repositories;

public static class VehiculoRepository
{
    public static string Ruta = "data/vehiculo.json";

    public static List<Vehiculo> CargarVehiculos()
    {
        try
        {
            return JsonUtility.CargarJson<List<Vehiculo>>(Ruta);
        }
        catch (FileNotFoundException)
        {
            return new List<Vehiculo>();
        }
    }

    public static void GuardarVehiculos(List<Vehiculo> vehiculos)
    {
        JsonUtility.GuardarJson(Ruta, vehiculos);
    }
}
