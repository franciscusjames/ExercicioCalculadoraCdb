using CalculadoraCdbApp.Apis.Shared;

namespace CalculadoraCdbApp.Apis.Cdb.Calcular;

public class CalculoCdbResponseDto : ResponseDto
{
    public double ResultadoBruto { get; set; }
    public double ResultadoLiquido { get; set; }
}
