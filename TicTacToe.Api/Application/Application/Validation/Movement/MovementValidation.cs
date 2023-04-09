using Application.Abstractions.DataAccess;
using Application.Contracts.Movements;
using FluentValidation;

namespace Application.Validation.Movement;

public class MovementValidation : AbstractValidator<MakeMove.Command>
{
    public MovementValidation(IDatabaseContext context)
    {
        RuleFor(x => x.GameId)
            .Must(x => context.Movements.Any(p => p.Id.Equals(x)))
            .WithMessage("This game doesn't exist");
        
        RuleFor(x => x.PlayerId)
            .Must(x => context.Movements.Any(p => p.Id.Equals(x)))
            .WithMessage("This player doesn't exist");
        
        RuleFor(x => x.Position)
            .Must(x => x is >= 0 and <= 8)
            .WithMessage("Incorrect position");
    }
}