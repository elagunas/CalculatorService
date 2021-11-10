using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CalculatorService.Application.Journal.Validators
{
    public class CalculatorMultValidator : AbstractValidator<Calculator.Commands.CalculatorMultCommand>
    {
        public CalculatorMultValidator()
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.MultOperationRequestDto)
                .NotNull().WithMessage("The request cannot be empty");

            RuleFor(x => x.MultOperationRequestDto.Factors).NotNull().WithMessage("Factors are required");

            RuleFor(x => x.MultOperationRequestDto.Factors).Must(x => x != null && x.Count() > 1).WithMessage("At leats two Factors are required");

        }
    }
}
