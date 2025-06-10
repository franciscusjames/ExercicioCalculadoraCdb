using CalculadoraCdbApp.Apis.Cdb.Calcular;
using CalculoCdbApp.UnitTests.Shared;

namespace CalculoCdbApp.UnitTests.App.Apis.ForFrontend.Cdb.Calcular;

internal class CalculoCdbResponseDtoBuilder : CoreBuilder<CalculoCdbResponseDto>
{
    private double? _resultadoBruto;
    private double? _resultadoLiquido;


    protected internal override Faker<CalculoCdbResponseDto> Faker() =>
    base.Faker()
        .RuleFor(x => x.ResultadoBruto, f => IsGenerateValuesWhenNullOrDefault() && _resultadoBruto is null
            ? Decimal.ToDouble(f.Finance.Amount())
            : _resultadoBruto)
        .RuleFor(x => x.ResultadoLiquido, f => IsGenerateValuesWhenNullOrDefault() && _resultadoLiquido is null
            ? Decimal.ToDouble(f.Finance.Amount())
            : _resultadoLiquido);


    internal CalculoCdbResponseDtoBuilder WithResultadoBruto(double? resultadoBruto)
    {
        _resultadoBruto = resultadoBruto;
        return this;
    }

    internal CalculoCdbResponseDtoBuilder WithResultadoLiquido(double? resultadoLiquido)
    {
        _resultadoLiquido = resultadoLiquido;
        return this;
    }
}
