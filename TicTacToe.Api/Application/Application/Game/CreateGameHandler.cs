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
        // var playerOne = await _context.Players.GetEntityAsync(request.PlayerOneId, cancellationToken);
        // var playerTwo = await _context.Players.GetEntityAsync(request.PlayerTwoId, cancellationToken);
        //
        // playerOne.MovementValue = (char)MovementValues.X;
        // playerTwo.MovementValue = (char)MovementValues.O;

        var game = new Domain.Games.Game(Guid.NewGuid());

        _context.Games.Add(game);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(game.AsDto());

    }
}