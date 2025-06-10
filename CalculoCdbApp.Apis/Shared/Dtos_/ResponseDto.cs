namespace CalculadoraCdbApp.Apis.Shared;

public class ResponseDto
{
    public ResponseStatus Status { get; set; }
    public BadRequestDto? BadRequestReason { get; set; }

    protected ResponseDto()
    {
        Status = ResponseStatus.OK;
    }
}
