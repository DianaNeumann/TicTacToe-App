using Domain.Players;

namespace Application.Dto;

public record GameDto(Guid Id, Player? PlayerOne, Player? PlayerTwo);