using Domain.Games.GameStates;

namespace Application.Dto;

public record GameStateDto(GameStatus Status, string Field);
