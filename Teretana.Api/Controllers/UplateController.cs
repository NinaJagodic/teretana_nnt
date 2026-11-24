using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teretana.Application.Uplate.Queries;
using Teretana.Domain.Entities;

namespace Teretana.Api.Controllers;

[ApiController]
[Route("uplate")]
public class UplateController : ControllerBase
{
    private readonly IMediator _mediator;

    public UplateController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<UplataDto>>> Get(
        [FromQuery] StatusUplate status,
        [FromQuery] DateTime od,
        [FromQuery] DateTime @do,
        CancellationToken ct)
    {
        var rezultat = await _mediator.Send(new GetUplateQuery(status, od, @do), ct);
        Response.Headers["X-Broj-Redova"] = rezultat.Count.ToString();
        return Ok(rezultat);
    }
}