using controllers;
using views;
namespace models.observers;

public class LogisticObserver
{
    public void Suscribir(PedidoService s) => s.PedidoConfirmado += OnPedidoConfirmado;

    public void OnPedidoConfirmado(object? sender, PedidoEventArgs e)
    {
        foreach (var p in e.Pedido.Products)
        {
            Console.WriteLine($" - {p.Cantidad} x {p.Nombre}[{p.Precio}]");
        }
        ConsoleLogger.Print($"Envio: {e.Pedido.Envio.Name} | Total: {e.Pedido.Total}",true);
        
    }
}