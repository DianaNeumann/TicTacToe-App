using Application.Dto;
using Domain.Games.GameStates;

namespace Application.Mapping;

public static class GameStateMapper
{
    public static GameStateDto AsDto(this GameState gameState)
        => new GameStateDto(gameState.Status, gameState.Field);
}