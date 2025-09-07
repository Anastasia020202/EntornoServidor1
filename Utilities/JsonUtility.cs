using System.Text.Json;

namespace ParkingApp1.Utilities;

public class JsonUtility
{
    public static void GuardarJson<T>(string ruta, T lista)
    {
        try
        {
            string fichero = JsonSerializer.Serialize(lista);
            using (StreamWriter sw = new StreamWriter(ruta))
            {
                sw.WriteLine(fichero);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al guardar JSON: {e}");
        }
    }

    public static T CargarJson<T>(string ruta)
    {
        try
        {
            if (!File.Exists(ruta))
            {
                throw new FileNotFoundException($"No se encontró el fichero: {ruta}");
            }

            string fichero = File.ReadAllText(ruta);
            T listaDeObjetos = JsonSerializer.Deserialize<T>(fichero)!;
            return listaDeObjetos;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al cargar JSON: {e}");
            throw;
        }
    }
}

