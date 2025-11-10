namespace models;
using System.Collections.Generic;
using models.interfaces;

public class Pedido
{
    public Pedido()
    {
        Products = new List<Producto>();
    }

    public List<Producto> Products { get; internal set; }
    public string Client { get; internal set; }
    
    public IEnvioStrategy Envio { get; internal set; }
    public decimal Total { get; internal set; }
    public string Direccion { get; internal set; }
    
    
}