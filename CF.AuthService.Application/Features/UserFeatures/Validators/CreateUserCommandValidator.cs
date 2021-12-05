
using CF.AuthService.Application.Common.Enums;
using CF.AuthService.Application.Features.UserFeatures.Commands;
using CF.ProjectService.Application.Features.UserFeatures.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.AuthService.Application.Features.UserFeatures.Validators
{
    class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(450)
                .NotEmpty();
            RuleFor(v => v.Email)
                .MaximumLength(450)
                .NotEmpty();
            RuleFor(v => v.RoleId)
                .NotEmpty();

            RuleFor(v=>v.UserPrincipal).MaximumLength(450).NotEmpty();

        }
    }
}
