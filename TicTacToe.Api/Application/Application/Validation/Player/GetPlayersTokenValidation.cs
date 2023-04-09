using Application.Contracts.Player;
using FluentValidation;

namespace Application.Validation.Player;

public class GetPlayersTokenValidation : AbstractValidator<GetPlayersToken.Command>
{
    public GetPlayersTokenValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Empty name");

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage("Empty password");
    }
}