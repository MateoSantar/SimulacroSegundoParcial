using controllers;
using models.interfaces;
using views;
namespace models.observers;

public class ClientObserver
{
    public void Suscribir(PedidoService s) => s.PedidoConfirmado += OnPedidoConfirmado;

    private void OnPedidoConfirmado(object? sender, PedidoEventArgs e)
    {
        ConsoleLogger.Print($"{e.Pedido.Client}! Tu pedido por ${e.Pedido.Total} fue confirmado. Tipo de envío: {e.Pedido.Envio.Name}.",true);
    }

}