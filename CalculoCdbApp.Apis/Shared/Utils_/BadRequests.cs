namespace CalculadoraCdbApp.Apis.Shared;

public static class BadRequests
{
    public static BadRequestDto BadRequestReasonFrom(string descricao) =>
        new BadRequestDto { new BadRequestDetailDto(descricao) };

    public static BadRequestDto BadRequestReasonFrom(
        IEnumerable<string> descricoes) =>
            new BadRequestDto(descricoes?.Select(x => new BadRequestDetailDto(x)));
}
