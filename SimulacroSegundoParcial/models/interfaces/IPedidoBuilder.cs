namespace models.interfaces;

public interface IPedidoBuilder
{
    IPedidoBuilder AddClient(Client c);
    IPedidoBuilder AddAddress(string address);
    IPedidoBuilder AddProducts(List<Producto> products);
    Pedido Build();
}