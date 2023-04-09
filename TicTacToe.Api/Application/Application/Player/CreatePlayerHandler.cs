using Application.Abstractions.DataAccess;
using Application.Mapping;
using Application.Services.Interfaces;
using MediatR;
using static Application.Contracts.Player.CreatePlayer;

namespace Application.Player;

public class CreatePlayerHandler  : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;
    private readonly IAuthService _service;

    public CreatePlayerHandler(IDatabaseContext context, IAuthService service)
    {
        _context = context;
        _service = service;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var player = await _service.RegisterAsync(request.Name, request.Password, cancellationToken);

        return new Response(player.AsDto());
    }
}