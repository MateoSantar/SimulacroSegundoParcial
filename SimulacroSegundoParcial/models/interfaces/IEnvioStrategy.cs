namespace models.interfaces;

public interface IEnvioStrategy
{
    string Name { get; }
    decimal Calcular(decimal subTotal); 

}