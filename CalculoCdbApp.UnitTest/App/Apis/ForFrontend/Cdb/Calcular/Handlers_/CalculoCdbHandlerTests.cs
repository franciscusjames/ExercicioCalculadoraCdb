using CalculadoraCdbApp.Apis.ForFrontend.Cdb.Calcular;
using CalculadoraCdbApp.Apis.Services;
using CalculadoraCdbApp.Apis.Shared;

namespace CalculoCdbApp.UnitTests.App.Apis.ForFrontend.Cdb.Calcular;

public class CalculoCdbHandlerTests
{
    private readonly CalculoCdbHandler _sut;
    private readonly CancellationToken _cancellationToken;
    private readonly ICalculadoraCdbService _calculadoraCdbService;

    public CalculoCdbHandlerTests()
    {
        _cancellationToken = new CancellationTokenSource().Token;
        _calculadoraCdbService = Substitute.For<ICalculadoraCdbService>();

        _sut = new CalculoCdbHandler(_calculadoraCdbService);
    }

    [Fact(DisplayName = "Retorna valor bruto e valor liquido com sucesso.")]
    [Trait("Handlers", "CalculoCdbHandler")]
    public async Task CalculoCdbHandler_Handle_RetornaValorBrutoEValorLiquido()
    {
        // Arrange
        var calculoCdbRequestDto = new CalculoCdbRequestDtoBuilder()
            .Build();

        double valorTeste = 2;

        _calculadoraCdbService.CalcularValorBruto(Arg.Any<double>(), Arg.Any<int>(), _cancellationToken)
            .Returns(valorTeste);

        _calculadoraCdbService.CalcularValorLiquido(Arg.Any<double>(), Arg.Any<int>(), _cancellationToken)
            .Returns(valorTeste);

        // Act
        var calculoCdbResponseDto = await _sut.Handle(calculoCdbRequestDto, _cancellationToken);

        // Assert
        calculoCdbResponseDto.BadRequestReason.Should().BeNull();
        calculoCdbResponseDto.Status.Should().Be(ResponseStatus.OK);
        calculoCdbResponseDto.ResultadoBruto.Should().BeGreaterThan(0);
        calculoCdbResponseDto.ResultadoLiquido.Should().BeGreaterThan(0);

        await _calculadoraCdbService
            .Received(1)
            .CalcularValorBruto(Arg.Any<double>(), Arg.Any<int>(), _cancellationToken);

        await _calculadoraCdbService
            .Received(1)
            .CalcularValorLiquido(Arg.Any<double>(), Arg.Any<int>(), _cancellationToken);
    }
}
