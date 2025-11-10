namespace models.interfaces;

public interface IRepositorio<T>
{
    void Guardar(T entidad);
    IEnumerable<T> ObtenerTodos();
}