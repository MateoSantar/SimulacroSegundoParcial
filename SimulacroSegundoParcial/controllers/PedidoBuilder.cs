using models;
using models.interfaces;
using models.strategies;

namespace controllers;

public class PedidoBuilder : IPedidoBuilder
{
    private Pedido _P;

    public PedidoBuilder()
    {
        _P = new Pedido();
    }

    public IPedidoBuilder AddAddress(string address)
    {
        _P.Direccion = address;
        return this;
    }

    public IPedidoBuilder AddClient(string c)
    {
        _P.Client = c;
        return this;
    }

    public IPedidoBuilder SetEnvio(string nombre)
    {
        switch (nombre.ToLower())
        {
            case "moto":
                _P.Envio = new EnvioMoto();
                break;
            case "correo":
                _P.Envio = new EnvioCorreo();
                break;
            case "retiro":
                _P.Envio = new Retiro();
                break;
            default:
                throw new ArgumentException("Nombre de envio no valido");
        }
        return this;
    }

    public IPedidoBuilder AddProduct(string nombre, decimal precio, int cantidad)
    {
        _P.Products.Add(new Producto(nombre,precio,cantidad));
        return this;
    }

    public Pedido Build()
    {
        if (_P.Products.Count == 0)
            throw new ArgumentException("El pedido debe tener productos");
        if (string.IsNullOrWhiteSpace(_P.Client) || string.IsNullOrWhiteSpace(_P.Direccion) || _P.Envio is null)
            throw new ArgumentException("Complete todos los datos del pedido");

        _P.Total = _P.Envio.Calcular(_P.Products.Sum(p => p.Cantidad*p.Precio));
        return _P;
    }

    public void Reset()
    {
        _P = new Pedido();
    }
}