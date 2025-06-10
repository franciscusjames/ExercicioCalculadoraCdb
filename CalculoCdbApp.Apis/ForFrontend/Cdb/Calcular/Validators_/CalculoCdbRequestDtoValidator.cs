using CalculadoraCdbApp.Apis.Cdb.Calcular;
using CalculadoraCdbApp.Apis.Shared;
using FluentValidation;

namespace CalculadoraCdbApp.Apis.ForFrontend.Cdb.Calcular;

public class CalculoCdbRequestDtoValidator : AbstractValidator<CalculoCdbRequestDto>
{
    public CalculoCdbRequestDtoValidator()
    {
        RuleFor(x => x.Valor)
            .GreaterThan(0)
            .WithMessage(Resources.ValorDeveSerMaiorQueZero);

        RuleFor(x => x.Prazo)
            .GreaterThan(0)
            .WithMessage(Resources.PrazoDeveSerMaiorQueZero);
    }
}
