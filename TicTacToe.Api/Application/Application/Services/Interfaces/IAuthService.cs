using Application.Dto;

namespace Application.Services.Interfaces;

public interface IAuthService
{
    Task<Domain.Players.Player> RegisterAsync(string name, string password, CancellationToken cancellationToken);

    Task<bool> IsPasswordCorrect(string name, string password);
    
    Task<Domain.Players.Player> GetPlayerByLogin(string name);
    string GenerateToken(Domain.Players.Player player);
}