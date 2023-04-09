namespace Application.Security.Tokens.Interfaces;

public interface ITokenManager
{
    string CreateToken(Domain.Players.Player player);
}