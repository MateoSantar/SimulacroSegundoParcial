namespace models;

public class Producto
{
    public Producto(string nombre, decimal precio, int cantidad)
    {
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }

    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
}