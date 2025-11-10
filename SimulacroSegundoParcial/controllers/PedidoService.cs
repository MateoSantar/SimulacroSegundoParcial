using models;
using models.observers;

namespace controllers;

public class PedidoService
{
    public event EventHandler<PedidoEventArgs>? PedidoConfirmado;

    public void ConfirmarPedido(Pedido p)
    {
        PedidoConfirmado?.Invoke(this,new PedidoEventArgs(p));
    }
}