using FluentValidation;
using MediatR;

namespace CalculadoraCdbApp.Apis.Shared;

public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResponseDto, new()
{
    private readonly IEnumerable<AbstractValidator<TRequest>> _validators;

    public FailFastRequestBehavior(IEnumerable<AbstractValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var dtoValidationResult = _validators
            .Select(v => v.Validate(request))
            .Where(v => !v.IsValid)
            .SelectMany(v => v.Errors)
            .ToList();

        return dtoValidationResult.Any()
            ? Task.FromResult(Responses.BadRequest<TResponse>(BadRequests.BadRequestReasonFrom(dtoValidationResult.Select(m => m.ErrorMessage))))
            : next();
    }
}
