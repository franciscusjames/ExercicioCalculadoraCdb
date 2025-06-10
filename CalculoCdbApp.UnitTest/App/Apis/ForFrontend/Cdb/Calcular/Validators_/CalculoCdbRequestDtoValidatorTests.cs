using CalculadoraCdbApp.Apis.ForFrontend.Cdb.Calcular;
using CalculadoraCdbApp.Apis.Shared;

namespace CalculoCdbApp.UnitTests.App.Apis.ForFrontend.Cdb.Calcular;

public class CalculoCdbRequestDtoValidatorTests
{
    private readonly CalculoCdbRequestDtoValidator _sut;

    public CalculoCdbRequestDtoValidatorTests()
    {
        _sut = new CalculoCdbRequestDtoValidator();
    }

    [Fact(DisplayName = "Deve retornar sucesso quando os campos forem informados.")]
    [Trait("Validators", "CalculoCdbRequestDtoValidator")]
    public void CalculoCdbRequestDtoValidator_Validate_RetornaSucessoParaCamposInformados()
    {
        // Arrange
        var calculoCdbRequestDto = new CalculoCdbRequestDtoBuilder()
            .WithPrazo(3)
            .WithValor(2)
            .Build();

        // Act
        var dtoValidationResult = _sut.Validate(calculoCdbRequestDto);

        // Assert
        dtoValidationResult.IsValid.Should().BeTrue();
    }

    [Fact(DisplayName = "Deve retornar falha quando um dos campos não for informado.")]
    [Trait("Validators", "CalculoCdbRequestDtoValidator")]
    public void CalculoCdbRequestDtoValidator_Validate_RetornaFalhaUmDosCamposNaoInformado()
    {
        // Arrange
        var calculoCdbRequestDto = new CalculoCdbRequestDtoBuilder()
            .WithPrazo(3)
            .WithValor(0)
            .Build();

        // Act
        var dtoValidationResult = _sut.Validate(calculoCdbRequestDto);

        // Assert
        dtoValidationResult.IsValid.Should().BeFalse();
        dtoValidationResult.Errors.Should().NotBeEmpty();
        dtoValidationResult.Errors.Count().Should().Be(1);
        dtoValidationResult.Errors.First().ErrorMessage.Should().Be(Resources.ValorDeveSerMaiorQueZero);
    }

    [Fact(DisplayName = "Deve retornar falha quando ambos campos forem zero.")]
    [Trait("Validators", "CalculoCdbRequestDtoValidator")]
    public void CalculoCdbRequestDtoValidator_Validate_RetornaFalhaAmbosCamposNaoInformados()
    {
        // Arrange
        var calculoCdbRequestDto = new CalculoCdbRequestDtoBuilder()
            .WithPrazo(0)
            .WithValor(0)
            .Build();

        // Act
        var dtoValidationResult = _sut.Validate(calculoCdbRequestDto);

        // Assert
        dtoValidationResult.IsValid.Should().BeFalse();
        dtoValidationResult.Errors.Should().NotBeEmpty();
        dtoValidationResult.Errors.Count().Should().Be(2);
        dtoValidationResult.Errors.Select(x => x.ErrorMessage).Should().Contain(Resources.ValorDeveSerMaiorQueZero);
        dtoValidationResult.Errors.Select(x => x.ErrorMessage).Should().Contain(Resources.PrazoDeveSerMaiorQueZero);
    }

    
}
