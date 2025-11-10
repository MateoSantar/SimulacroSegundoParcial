namespace models.interfaces;

public interface IPedidoBuilder
{
    IPedidoBuilder AddClient(string c);
    IPedidoBuilder AddAddress(string address);
    IPedidoBuilder AddProduct(string nombre, decimal precio, int cantidad);
    IPedidoBuilder SetEnvio(string nombre);

    void Reset();
    Pedido Build();
}