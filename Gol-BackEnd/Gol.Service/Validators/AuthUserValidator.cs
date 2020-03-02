using FluentValidation;
using System;
using Gol.Domain.Entities;

namespace Gol.Service.Validators
{
    public class AuthUserValidator : AbstractValidator<AuthUser>
    {
        public AuthUserValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });
        }
    }
}
