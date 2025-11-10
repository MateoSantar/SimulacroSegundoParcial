using models.interfaces;

namespace models.strategies;

public class EnvioMoto : IEnvioStrategy
{
    public string Name => "Moto";

    public decimal Calcular(decimal subTotal)
    {
        return subTotal + subTotal * 0.10m;
    }
}