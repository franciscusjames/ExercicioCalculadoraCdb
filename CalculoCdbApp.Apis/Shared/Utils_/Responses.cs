namespace CalculadoraCdbApp.Apis.Shared;

public static class Responses
{
    public static T OK<T>(Action<T> act = null)
            where T : ResponseDto, new() =>
                CreateResponse(ResponseStatus.OK, act);

    public static T BadRequest<T>(
        BadRequestDto badReqReason = null, Action<T> act = null)
            where T : ResponseDto, new()
    {
        var resp = CreateResponse(ResponseStatus.BadRequest, act);
        resp.BadRequestReason = badReqReason;
        return resp;
    }

    private static T CreateResponse<T>(
        ResponseStatus status, Action<T> act = null)
            where T : ResponseDto, new()
    {
        var resp = new T { Status = status };
        act?.Invoke(resp);
        return resp;
    }
}
