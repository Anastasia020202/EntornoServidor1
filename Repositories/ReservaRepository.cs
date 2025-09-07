using ParkingApp1.Models;
using ParkingApp1.Utilities;

namespace ParkingApp1.Repositories;

public static class ReservaRepository
{
    public static string Ruta = "data/reserva.json";

    public static List<Reserva> CargarReservas()
    {
        try
        {
            return JsonUtility.CargarJson<List<Reserva>>(Ruta);
        }
        catch (FileNotFoundException)
        {
            return new List<Reserva>();
        }
    }

    public static void GuardarReservas(List<Reserva> reservas)
    {
        JsonUtility.GuardarJson(Ruta, reservas);
    }
}
