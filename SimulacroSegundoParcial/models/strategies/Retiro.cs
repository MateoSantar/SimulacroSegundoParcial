using models.interfaces;

namespace models.strategies;

public class Retiro : IEnvioStrategy
{
    public string Name => "Retiro";

    public decimal Calcular(decimal subTotal)
    {
        return subTotal;
    }
}