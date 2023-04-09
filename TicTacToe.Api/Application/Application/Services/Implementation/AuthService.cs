using Application.Abstractions.DataAccess;
using Application.Security.Tokens.Interfaces;
using Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MPS.Domain.Modules.SecurityModules.PasswordModule.Interfaces;

namespace Application.Services.Implementation;

public class AuthService : IAuthService
{
    private readonly IDatabaseContext _context;
    private readonly IPasswordManager _passwordManager;
    private readonly ITokenManager _tokenManager;

    public AuthService(IDatabaseContext context, IPasswordManager passwordManager, ITokenManager tokenManager)
    {
        _context = context;
        _passwordManager = passwordManager;
        _tokenManager = tokenManager;
    }

    public async Task<Domain.Players.Player> RegisterAsync(string name, string password, CancellationToken cancellationToken)
    {
        var passwordHash = _passwordManager.CreatePasswordHash(password);
        var player = new Domain.Players.Player(name, passwordHash);

        _context.Players.Add(player);
        await _context.SaveChangesAsync(cancellationToken);

        return player;
    }
    

    public async Task<bool> IsPasswordCorrect(string name, string password)
    {
        var player = await GetPlayerByLogin(name);

        var isPasswordCorrect = _passwordManager.VerifyPasswordHash(password, player.PasswordHash);
        return isPasswordCorrect;
    }
    
    public async Task<Domain.Players.Player> GetPlayerByLogin(string name)
    {
        return await _context.Players.FirstAsync(a => a.Name.Equals(name));
    }

    public string GenerateToken(Domain.Players.Player player) => _tokenManager.CreateToken(player);
}