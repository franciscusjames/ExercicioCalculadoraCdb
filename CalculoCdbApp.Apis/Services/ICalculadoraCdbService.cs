namespace CalculadoraCdbApp.Apis.Services
{
    public interface ICalculadoraCdbService
    {
        Task<double> CalcularValorBruto(double valorInicial, int prazo, CancellationToken ct);
        Task<double> CalcularValorLiquido(double valorBruto, int prazo, CancellationToken ct);
    }
}
