using System.Text;
using models;
using models.interfaces;
using views;

namespace controllers;

public class PedidoFacade
{
    private readonly IPedidoBuilder _builder;
    private readonly PedidoService _service;
    private readonly IRepositorio<Pedido> _repo;

    public PedidoFacade(IPedidoBuilder builder, PedidoService service, IRepositorio<Pedido> repo)
    {
        _builder = builder;
        _service = service;
        _repo = repo;
    }



    public void Reset() => _builder.Reset();

    public void AddProduct(string nombre, decimal precio, int cantidad)
    {
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El producto debe tener nombre");
        if (precio < 0) throw new ArgumentException("El precio debe ser positivo");
        if (cantidad <= 0) throw new ArgumentException("La cantidad debe ser positiva");
        _builder.AddProduct(nombre, precio, cantidad);
    }

    public void AddEnvio(string e)
    {
        _builder.SetEnvio(e);
    }

    public void AddClient(string c,string d)
    {
        if (string.IsNullOrWhiteSpace(c) || string.IsNullOrWhiteSpace(d)) throw new ArgumentException("Debe haber un cliente y una direccion");
        _builder.AddClient(c);
        _builder.AddAddress(d);
    }

    public string GenerateSummary()
    {
        try
        {
            Pedido p = _builder.Build();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" Resumen ");
            foreach (Producto item in p.Products)
            {
                sb.AppendLine($"{item.Nombre} | {item.Cantidad} = {item.Precio * item.Cantidad}");
            }
            sb.AppendLine($" Total actual: {p.Total}");
            return sb.ToString();
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    public void ConfirmarPedido()
    {
        try
        {
            Pedido p = _builder.Build();
            _service.ConfirmarPedido(p);
            _repo.Guardar(p);
        }
        catch (Exception)
        {
            throw;
        }

    }
}