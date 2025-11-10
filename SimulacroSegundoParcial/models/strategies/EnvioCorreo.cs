using models.interfaces;

namespace models.strategies;

public class EnvioCorreo : IEnvioStrategy
{
    public string Name => "Correo";

    public decimal Calcular(decimal subTotal)
    {
        return subTotal + subTotal * 0.10m;

    }
}