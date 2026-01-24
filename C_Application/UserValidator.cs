using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B_Infrastructure.dto;
using B_Infrastructure.dtodotnet;
using FluentValidation;

namespace C_Application
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
