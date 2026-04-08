using FluentValidation;
using SnakeBE.Domain;
using SnakeBE.Domain.dto;

namespace SnakeBE.Application
{
    public class UserValidator : AbstractValidator<LoginModel>
    {
        public UserValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("è richiesto uno username")
                .MinimumLength(8).WithMessage(" Lo username deve essere di almeno 8 caratteri");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("è richiesto una password")
                .MinimumLength(8).WithMessage(" Lo username deve essere di almeno 8 caratteri");
        }
    }
}
