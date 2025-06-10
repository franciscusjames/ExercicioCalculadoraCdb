namespace CalculadoraCdbApp.Apis.Shared;

public class BadRequestDetailDto
{
    public string Descricao { get; set; }

    public BadRequestDetailDto(string descricao)
    {
        Descricao = descricao;
    }
}
