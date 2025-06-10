using CalculadoraCdbApp.Apis.Services;
using CalculoCdbApp.UnitTests.App.Apis.ForFrontend.Cdb.Calcular;

namespace CalculoCdbApp.UnitTests.App.Apis.Services;

public class CalculadoraCdbServiceTests
{
    private readonly CalculadoraCdbService _sut;
    private readonly CancellationToken _cancellationToken;

    public CalculadoraCdbServiceTests()
    {
        _cancellationToken = new CancellationTokenSource().Token;
        _sut = new CalculadoraCdbService();
    }

    [Fact(DisplayName = "Retorna valor bruto esperado.")]
    [Trait("Services", "CalculadoraCdbService")]
    public async Task CalculadoraCdbService_CalcularValorBruto_SucessoRetornoValorBruto()
    {
        // Arrange
        var calculoCdbRequestDto = new CalculoCdbRequestDtoBuilder()
            .WithPrazo(2)
            .WithValor(1.53)
            .Build();

        // Act
        var valorBruto = await _sut.CalcularValorBruto(calculoCdbRequestDto.Valor, calculoCdbRequestDto.Prazo, _cancellationToken);

        // Assert
        valorBruto.Should().Be(1.5448716);      
    }

    [Fact(DisplayName = "Retorna valor liquido esperado.")]
    [Trait("Services", "CalculadoraCdbService")]
    public async Task CalculadoraCdbService_CalcularValorLiquido_SucessoRetornoValorLiquido()
    {
        // Arrange
        var calculoCdbRequestDto = new CalculoCdbRequestDtoBuilder()
            .WithPrazo(2)
            .WithValor(1.53)
            .Build();

        // Act
        var valorBruto = await _sut.CalcularValorBruto(calculoCdbRequestDto.Valor, calculoCdbRequestDto.Prazo, _cancellationToken);
        var valorLiquido = await _sut.CalcularValorLiquido(valorBruto, calculoCdbRequestDto.Prazo, _cancellationToken);

        // Assert
        valorLiquido.Should().Be(1.19727549);
    }
}
