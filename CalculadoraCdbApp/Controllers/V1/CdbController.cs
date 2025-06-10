using CalculadoraCdbApp.Apis.Cdb.Calcular;
using CalculadoraCdbApp.Apis.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace CalculadoraCdbApp.Hosts.Http.ForFrontend.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/[controller]")]
public class CdbController : ControllerBase
{
    private readonly IMediator _mediator;

    public CdbController(IMediator mediator)
    {
        _mediator = mediator ?? throw (new ArgumentNullException(nameof(mediator)));
    }

    [HttpPost("calcular")]
    [ProducesResponseType(typeof(BadRequestDto), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CalculoCdbResponseDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CalcularAsync([FromBody] CalculoCdbRequestDto requestDto, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(requestDto, cancellationToken);

        return response.Status == ResponseStatus.OK
            ? Ok(response)
            : BadRequest(response);
    }
}
