using FluentValidation;
using SnakeBE.Infrastructure.dto;

namespace SnakeBE.Application
{
    public class GameValidator : AbstractValidator<GameDto>
    {
        public GameValidator() 
        { 
            RuleFor(game => game.Points)
                .NotEmpty().WithMessage("Il punteggio è richiesto")
                .GreaterThanOrEqualTo(0).WithMessage("Il punteggio deve essere maggiore di 0");

            RuleFor(game => game.Time)
                .NotEmpty().WithMessage("Il tempo di gioco è richiesto")
                .GreaterThanOrEqualTo(0).WithMessage("la data deve essere maggiore di 0");
        }

    }
}
