using controllers;
using models;
using models.interfaces;
using models.observers;
using repo;
using views;

namespace SimulacroSegundoParcial;

class Program
{
    static void Main(string[] args)
    {
        IRepositorio<Pedido> repo = new RepositorioJson<Pedido>("pedidos.json");
        IPedidoBuilder builder = new PedidoBuilder();
        PedidoService service = new PedidoService();
        ClientObserver clientObserver = new ClientObserver();
        LogisticObserver logisticObserver = new LogisticObserver();
        clientObserver.Suscribir(service);
        logisticObserver.Suscribir(service);
        PedidoFacade facade = new PedidoFacade(builder, service, repo);
        MostrarMenu(facade);

    }
    static void MostrarMenu(PedidoFacade facade)
    {
        var op = "9";
        while (op != "0")
        {
            Console.Clear();
            ConsoleLogger.Print("=== Checkout – ParcialPedidos ===",true);
            ConsoleLogger.Print("1) Cargar datos del cliente",true);
            ConsoleLogger.Print("2) Agregar producto",true);
            ConsoleLogger.Print("3) Seleccionar tipo de envío (moto/correo/retiro)",true);
            ConsoleLogger.Print("4) Ver resumen actual",true);
            ConsoleLogger.Print("5) Confirmar pedido",true);
            ConsoleLogger.Print("0) Salir",true);
            ConsoleLogger.Print("Opción: ",false);
            op = Console.ReadLine()?.Trim();

            try
            {
                switch (op)
                {
                    case "1":
                        CargarCliente(facade);
                        break;
                    case "2":
                        AgregarProducto(facade);
                        break;
                    case "3":
                        SeleccionarEnvio(facade);
                        break;
                    case "4":
                        ConsoleLogger.Print(facade.GenerateSummary(),true);
                        Pausa();
                        break;
                    case "5":
                        try
                        {
                            facade.ConfirmarPedido();
                            ConsoleLogger.Print("Pedido confirmado y guardado en pedidos.json",true);
                        }
                        catch (Exception ex)
                        {
                            ConsoleLogger.PrintError(ex.Message, true);
                        }
                        Pausa();
                        facade.Reset();
                        break;
                    case "0":
                        ConsoleLogger.Print("Adios!!",true);
                        break;
                    default:
                       ConsoleLogger.Print("Opción inválida",true);
                        Pausa();
                        break;
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.PrintError($"Error: {ex.Message}",true);
                Pausa();
            }
        }
    }

    static void CargarCliente(PedidoFacade facade)
    {
        ConsoleLogger.Print("Nombre del cliente: ",false);
        var nombre = Console.ReadLine() ?? string.Empty;
        ConsoleLogger.Print("Direccion del cliente: ", false);
        var direccion = Console.ReadLine() ?? string.Empty;
        facade.AddClient(nombre, direccion);
        ConsoleLogger.Print("Datos cargados.",true);
        Pausa();
    }

    static void AgregarProducto(PedidoFacade facade)
    {
        ConsoleLogger.Print("Nombre del producto: ",false);
        var nombre = Console.ReadLine() ?? string.Empty;

        ConsoleLogger.Print("Precio (ej 1999,99): ",false);
        if (!decimal.TryParse(Console.ReadLine(), out var precio) || precio < 0)
            throw new ArgumentException("Precio inválido");

        Console.Write("Cantidad: ");
        if (!int.TryParse(Console.ReadLine(), out var cantidad) || cantidad <= 0)
            throw new ArgumentException("Cantidad inválida");

        facade.AddProduct(nombre, precio, cantidad);
        ConsoleLogger.Print("Producto agregado.",true);
        Pausa();
    }

    static void SeleccionarEnvio(PedidoFacade facade)
    {
        ConsoleLogger.Print("Tipo de envío (moto/correo/retiro): ",false);
        var tipo = Console.ReadLine()?.Trim().ToLowerInvariant() ?? "";
        facade.AddEnvio(tipo);
        ConsoleLogger.Print("Estrategia de envío aplicada.",true);
        Pausa();
    }

    static void Pausa()
    {
        ConsoleLogger.Print("Presioná una tecla para continuar...",false);
        Console.ReadKey();
    }
}

