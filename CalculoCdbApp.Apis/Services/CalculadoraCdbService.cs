using CalculadoraCdbApp.Apis.Shared;

namespace CalculadoraCdbApp.Apis.Services
{
    public class CalculadoraCdbService : ICalculadoraCdbService
    {
        public async Task<double> CalcularValorBruto(double valorInicial, int prazo, CancellationToken ct)
        {
            var factor = 1 + (Defaults.CDI * Defaults.TB);

            var valorBruto = valorInicial * factor;

            return valorBruto;
        }

        public async Task<double> CalcularValorLiquido(double valorBruto, int prazo, CancellationToken ct)
        {
            double valorLiquido = 0;
            double taxa = 0;

            if (prazo <= 6)
                taxa = Defaults.AteSeisMeses;

            if (prazo > 6 && prazo <= 12)
                taxa = Defaults.AteUmAno;

            if (prazo > 12 && prazo <= 24)
                taxa = Defaults.AteDoisAnos;

            if (prazo > 24)
                taxa = Defaults.AcimaDoisAnos;

            return valorLiquido = valorBruto * (1 - taxa);
        }
    }
}
