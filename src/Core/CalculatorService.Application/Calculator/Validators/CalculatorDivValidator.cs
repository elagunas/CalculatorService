using CalculatorService.Api.Contracts.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService.Application.Journal.Validators
{
    public class CalculatorDivValidator : AbstractValidator<Calculator.Commands.CalculatorDivCommand>
    {
        public CalculatorDivValidator()
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.DivOperationRequestDto).NotNull().SetValidator(new DivOperationRequestDtoValidator());
        }


        public class DivOperationRequestDtoValidator : AbstractValidator<DivOperation.RequestDto>
        {
            public DivOperationRequestDtoValidator()
            {
                ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;

                RuleFor(x => x).NotNull().WithMessage("The request cannot be empty");

                RuleFor(x => x.Divisor)
                .NotNull().WithMessage("Divisor is required")
                .NotEqual(0).WithMessage("Divisor cannot be 0");

                RuleFor(x => x.Dividend)
                    .NotNull().WithMessage("Dividend is required");
            }

          
        }
    }
}
