namespace models.observers;
public class PedidoEventArgs : EventArgs
{
    public PedidoEventArgs(Pedido pedido)
    {
        Pedido = pedido;
    }

    public Pedido Pedido { get; }


    
}