using Application.Contracts.Player;
using Application.Dto;
using MediatR;
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
    public async Task<ActionResult<PlayerDto>> RegisterAsync([FromBody] InputPlayerModel model)
    {
        var command = new Command(model.Name, model.Password);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Player);
    }
    
    [HttpPost("Login")]
    public async Task<ActionResult<string>> LoginAsync([FromBody] InputPlayerModel model)
    {
        var command = new GetPlayersToken.Command(model.Name, model.Password);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Token);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PlayerDto>> GetPlayerByIdAsync(Guid id)
    {
        var query = new Query(id);
        var response = await _mediator.Send(query, CancellationToken);
        
        return Ok(response.Player);
    }
    
    
    
}