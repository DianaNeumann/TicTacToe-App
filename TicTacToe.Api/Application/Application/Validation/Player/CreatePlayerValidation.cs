using Application.Abstractions.DataAccess;
using Application.Contracts.Movements;
using Application.Contracts.Player;
using FluentValidation;

namespace Application.Validation.Player;

public class CreatePlayerValidation : AbstractValidator<CreatePlayer.Command>
{
    public CreatePlayerValidation(IDatabaseContext context)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Empty name")
            .Must(x => !context.Players.Any(p => p.Id.Equals(x)))
            .WithMessage("Name must be unique");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage("Empty password");
    }
}