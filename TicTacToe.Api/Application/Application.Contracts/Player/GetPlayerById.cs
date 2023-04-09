using Application.Dto;
using MediatR;

namespace Application.Contracts.Player;

public class GetPlayerById
{
    public record Query(Guid PlayerId) : IRequest<Response>;
    public record Response(PlayerDto Player);
}