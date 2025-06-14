﻿namespace CalculadoraCdbApp.Apis.Shared;

public class BadRequestDto : List<BadRequestDetailDto>
{
    public BadRequestDto() { }
    public BadRequestDto(IEnumerable<BadRequestDetailDto> collection) : base(collection) { }
    public BadRequestDto(params BadRequestDetailDto[] collection) : this((IEnumerable<BadRequestDetailDto>)collection) { }
}
