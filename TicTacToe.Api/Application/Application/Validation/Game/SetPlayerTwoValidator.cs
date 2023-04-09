using Application.Abstractions.DataAccess;
using Application.Contracts.Game;
using FluentValidation;

namespace Application.Validation.Game;

public class SetPlayerTwoValidator : AbstractValidator<SetPlayerTwo.Command>
{
    public SetPlayerTwoValidator(IDatabaseContext context)
    {
        RuleFor(x => x.GameId)
            .Must(x => context.Games.Any(p => p.Id.Equals(x)))
            .WithMessage("This game doesn't exist");
        
        RuleFor(x => x.PlayerId)
            .Must(x => context.Players.Any(p => p.Id.Equals(x)))
            .WithMessage("This player doesn't exist");
        
        RuleFor(x => x.PlayerId)
            .Must(x => context.Players
                .First(p=> p.Id.Equals(x))
                .IsPlaying != true)
            .WithMessage("This player is playing now");
    }
    
}