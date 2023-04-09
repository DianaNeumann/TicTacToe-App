using Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Movements;
using static Application.Contracts.Movements.MakeMove;

namespace Presentation.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovementController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public MovementController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("MakeMove")]
    public async Task<ActionResult<GameStateDto>> MakeMoveAsync([FromBody] MakeMoveModel model)
    {
        var command = new Command(model.GameId, model.PlayerId, model.Position);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.GameState);
    }


    
}