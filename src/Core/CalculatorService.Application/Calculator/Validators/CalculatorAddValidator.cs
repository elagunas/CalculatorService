using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorService.Application.Journal.Validators
{
    public class CalculatorAddValidator : AbstractValidator<Calculator.Commands.CalculatorAddCommand>
    {
        public CalculatorAddValidator()
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.AddOperationRequestDto)
                .NotNull().WithMessage("The request cannot be empty");

            RuleFor(x => x.AddOperationRequestDto.Addens).NotNull().WithMessage("Addens are required");

            RuleFor(x => x.AddOperationRequestDto.Addens).Must(x => x!= null && x.Count() > 1).WithMessage("At leats two Addens are required");
        }
    }
}
