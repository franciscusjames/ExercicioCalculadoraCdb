using CalculadoraCdbApp.Apis.Cdb.Calcular;
using CalculoCdbApp.UnitTests.Shared;

namespace CalculoCdbApp.UnitTests.App.Apis.ForFrontend.Cdb.Calcular;

internal class CalculoCdbRequestDtoBuilder : CoreBuilder<CalculoCdbRequestDto>
{
    private double? _valor;
    private int? _prazo;


    protected internal override Faker<CalculoCdbRequestDto> Faker() =>
    base.Faker()
        .RuleFor(x => x.Valor, f => IsGenerateValuesWhenNullOrDefault() && _valor is null
            ? Decimal.ToDouble(f.Finance.Amount())
            : _valor)
        .RuleFor(x => x.Prazo, f => IsGenerateValuesWhenNullOrDefault() && _prazo is null
            ? f.Random.Int()
            : _prazo);


    internal CalculoCdbRequestDtoBuilder WithPrazo(int? prazo)
    {
        _prazo = prazo;
        return this;
    }

    internal CalculoCdbRequestDtoBuilder WithValor(double? valor)
    {
        _valor = valor;
        return this;
    }
}
