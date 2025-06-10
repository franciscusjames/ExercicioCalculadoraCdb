using CalculadoraCdbApp.Apis.Cdb.Calcular;
using CalculadoraCdbApp.Apis.Services;
using MediatR;

namespace CalculadoraCdbApp.Apis.ForFrontend.Cdb.Calcular;

public class CalculoCdbHandler : IRequestHandler<CalculoCdbRequestDto, CalculoCdbResponseDto>
{
    private readonly ICalculadoraCdbService _calculadoraCdbService;

    public CalculoCdbHandler(ICalculadoraCdbService calculadoraCdbService)
    {
        _calculadoraCdbService = calculadoraCdbService ?? throw (new ArgumentNullException(nameof(calculadoraCdbService)));
    }

    public async Task<CalculoCdbResponseDto> Handle(CalculoCdbRequestDto request, CancellationToken cancellationToken)
    {
        var valorBruto = await _calculadoraCdbService.CalcularValorBruto(request.Valor, request.Prazo, cancellationToken);

        var valorLiquido = await _calculadoraCdbService.CalcularValorLiquido(valorBruto, request.Prazo, cancellationToken);

        return new CalculoCdbResponseDto { ResultadoBruto = valorBruto, ResultadoLiquido = valorLiquido, BadRequestReason = null };
    }
}
