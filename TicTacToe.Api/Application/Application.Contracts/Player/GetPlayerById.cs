using Application.Dto;
using MediatR;

namespace Application.Contracts.Player;

public class GetPlayerById
{
    public record Query(int PlayerId) : IRequest<Response>;
    public record Response(PlayerDto Player);
}