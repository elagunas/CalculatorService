using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService.Application.Journal.Validators
{
    public class CalculatorSqrtValidator : AbstractValidator<Calculator.Commands.CalculatorSqrtCommand>
    {
        public CalculatorSqrtValidator()
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.SqrtOperationRequestDto)
                .NotNull().WithMessage("The request cannot be empty");

            RuleFor(x => x.SqrtOperationRequestDto.Number)
                .NotNull().WithMessage("Number is required");
        }
    }
}
