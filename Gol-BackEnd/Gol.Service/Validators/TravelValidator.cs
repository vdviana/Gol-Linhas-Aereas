using FluentValidation;
using System;
using Gol.Domain.Entities;

namespace Gol.Service.Validators
{
    public class TravelValidator : AbstractValidator<Travel>
    {
        public TravelValidator()
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
