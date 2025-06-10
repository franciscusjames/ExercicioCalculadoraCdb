using MediatR;

namespace CalculadoraCdbApp.Apis.Cdb.Calcular;

public class CalculoCdbRequestDto : IRequest<CalculoCdbResponseDto>
{
    public double Valor { get; set; }
    public int Prazo { get; set; }
}

