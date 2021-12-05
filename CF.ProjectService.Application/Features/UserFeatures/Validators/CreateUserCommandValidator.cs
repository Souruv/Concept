using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Features.UserFeatures.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.UserFeatures.Validators
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
            RuleFor(v => v.Role)
                .GreaterThanOrEqualTo((int)UserRole.User)
                .LessThanOrEqualTo((int)UserRole.AdminUser);

            RuleFor(v=>v.UserPrincipal).MaximumLength(450).NotEmpty();

        }
    }
}
