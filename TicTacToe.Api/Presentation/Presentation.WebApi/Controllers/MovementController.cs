using Application.Contracts.Movements;
using Application.Dto;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Models.Movements;
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
    public async Task<ActionResult<GameStateDto>> MakeMoveAsync(
        [FromBody] MakeMoveModel model,
        [FromServices] IValidator<MakeMove.Command> validator)
    {
        var command = new Command(model.GameId, model.PlayerId, model.Position);
        
        var validationResult = await validator.ValidateAsync(command, CancellationToken);
        if (!validationResult.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors.Select(x => x.ErrorMessage));
        }
        
        
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.GameState);
    }


    
}