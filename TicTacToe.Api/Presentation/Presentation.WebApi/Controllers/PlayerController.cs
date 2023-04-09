using Application.Contracts.Player;
using Application.Dto;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Models.Players;
using static Application.Contracts.Player.CreatePlayer;
using static Application.Contracts.Player.GetPlayerById;

namespace Presentation.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
 
    private readonly IMediator _mediator;

    public PlayerController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public CancellationToken CancellationToken => HttpContext.RequestAborted;
    
    [HttpPost("Register")]
    public async Task<ActionResult<PlayerDto>> RegisterAsync(
        [FromBody] InputPlayerModel model,
        [FromServices] IValidator<CreatePlayer.Command> validator)
    {
        var command = new Command(model.Name, model.Password);
        
        var validationResult = await validator.ValidateAsync(command, CancellationToken);
        if (!validationResult.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors.Select(x => x.ErrorMessage));
        }
        
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Player);
    }
    
    [HttpPost("Login")]
    public async Task<ActionResult<string>> LoginAsync(
        [FromBody] InputPlayerModel model,
        [FromServices] IValidator<GetPlayersToken.Command> validator)
    {
        var command = new GetPlayersToken.Command(model.Name, model.Password);
        
        var validationResult = await validator.ValidateAsync(command, CancellationToken);
        if (!validationResult.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors.Select(x => x.ErrorMessage));
        }
        
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Token);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PlayerDto>> GetPlayerByIdAsync(int id)
    {
        var query = new Query(id);
        var response = await _mediator.Send(query, CancellationToken);
        
        return Ok(response.Player);
    }
    
    
    
}