using Application.Dto;

namespace Application.Mapping;

public static class GameMapping
{
    public static GameDto AsDto(this Domain.Games.Game game)
        => new GameDto(game.Id, game.PlayerOne, game.PlayerTwo);
}