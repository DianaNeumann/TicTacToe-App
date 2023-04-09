using Application.Abstractions.DataAccess;
using Application.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.Player.GetPlayersToken;

namespace Application.Player;

public class GetPlayersTokenHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;
    private readonly IAuthService _service;

    public GetPlayersTokenHandler(IDatabaseContext context, IAuthService service)
    {
        _context = context;
        _service = service;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {

        var player =
            await _context.Players.FirstAsync(a => a.Name.Equals(request.Name), cancellationToken);
        
        var token = _service.GenerateToken(player);
        return new Response(token);
    }
}