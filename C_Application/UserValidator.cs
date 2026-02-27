using FluentValidation;
using SnakeBE.Infrastructure.dto;

namespace SnakeBE.Application
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("è richiesto uno username")
                .MinimumLength(8).WithMessage(" Lo username deve essere di almeno 8 caratteri");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("è richiesta una password")


                 .MinimumLength(8).WithMessage(" La password deve essere di almeno 8 caratteri");
        }
    }
}
