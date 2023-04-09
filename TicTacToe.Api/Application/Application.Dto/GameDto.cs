using Domain.Players;

namespace Application.Dto;

public record GameDto(int Id, Player? PlayerOne, Player? PlayerTwo);