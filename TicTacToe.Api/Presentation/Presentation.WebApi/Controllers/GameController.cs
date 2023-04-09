using Application.Contracts.Game;
using Application.Dto;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Models.Games;
using static Application.Contracts.Game.CreateGame;
using static Application.Contracts.Game.GetGameById;
using static Application.Contracts.Game.SetPlayerOne;

namespace Presentation.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GameController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    
    [HttpPost("CreateGame")]
    [Authorize]
    public async Task<ActionResult<GameDto>> CreateGameAsync()
    {
        var command = new CreateGame.Command();
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Game);
    }

    [HttpPut("SetPlayerOne")]
    public async Task<ActionResult<GameDto>> SetPlayerOneAsync(
        [FromBody] SetPlayerModel model,
        [FromServices] IValidator<SetPlayerOne.Command> validator)
    { 
        var command = new SetPlayerOne.Command(model.GameId, model.PlayerId);
        
        var validationResult = await validator.ValidateAsync(command, CancellationToken);
        if (!validationResult.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors.Select(x => x.ErrorMessage));
        }
        
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Game);
    }
    
    [HttpPut("SetPlayerTwo")]
    public async Task<ActionResult<GameDto>> SetPlayerTwoAsync(
        [FromBody] SetPlayerModel model,
        [FromServices] IValidator<SetPlayerTwo.Command> validator)
    { 
        var command = new SetPlayerTwo.Command(model.GameId, model.PlayerId);
        
        var validationResult = await validator.ValidateAsync(command, CancellationToken);
        if (!validationResult.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors.Select(x => x.ErrorMessage));
        }
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Game);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GameDto>> GetGameByIdAsync(Guid id)
    {
        var query = new Query(id);
        var response = await _mediator.Send(query, CancellationToken);
        
        return Ok(response.Game);
    }
}