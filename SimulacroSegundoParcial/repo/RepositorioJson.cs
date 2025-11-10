namespace repo;

using System.Collections.Generic;
using System.Text.Json;
using models;
using views;
using models.interfaces;
public class RepositorioJson<T> : IRepositorio<T>
{

    private readonly string _path;

    private static readonly JsonSerializerOptions _opts = new()
    {
        WriteIndented = true
    };

    public RepositorioJson(string path)
    {
        _path = path;
    }

    public void Guardar(T obj)
    {
        List<T> data = new();

        if (File.Exists(_path))
        {
            try
            {
                string json = File.ReadAllText(_path);

                if (!string.IsNullOrEmpty(json))
                {
                    List<T>? json_list = JsonSerializer.Deserialize<List<T>>(json, _opts);
                    if (json_list != null)
                    {
                        data = json_list;
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.PrintError($"Error al leer {_path}: {ex.Message}", true);
            }
        }

        data.Add(obj);

        try
        {
            File.WriteAllText(_path, JsonSerializer.Serialize(data, _opts));
        }
        catch (Exception ex)
        {
            ConsoleLogger.PrintError($"Error al guardar en {_path}: {ex.Message}", true);
        }
    }

    public IEnumerable<T> ObtenerTodos()
    {
        if (File.Exists(_path))
        {
            try
            {
                string json = File.ReadAllText(_path);
                List<T>? json_list = JsonSerializer.Deserialize<List<T>>(json, _opts);
                if (json_list != null) return json_list;
            }
            catch (Exception ex)
            {
                ConsoleLogger.PrintError($"Error = {ex.Message}", true);

            }
        }
        return Enumerable.Empty<T>();

    }
}