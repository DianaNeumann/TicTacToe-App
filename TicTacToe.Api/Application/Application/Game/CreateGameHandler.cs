using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using Domain.Movements;
using MediatR;
using static Application.Contracts.Game.CreateGame;

namespace Application.Game;

public class CreateGameHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateGameHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var game = new Domain.Games.Game();

        _context.Games.Add(game);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(game.AsDto());

    }
}