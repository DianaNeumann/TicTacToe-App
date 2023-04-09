using Application.Dto;

namespace Application.Mapping;

public static class PlayerMapping
{
    public static PlayerDto AsDto(this Domain.Players.Player player)
        => new PlayerDto(player.Id, player.Name, player.EarnedPoints, player.IsPlaying);
}