using CalculatorService.Api.Contracts.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService.Application.Journal.Validators
{
    public class CalculatorSubValidator : AbstractValidator<Calculator.Commands.CalculatorSubCommand>
    {
        public CalculatorSubValidator()
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.SubOperationRequestDto).NotNull().SetValidator(new SubOperationRequestDtoValidator());

        }

        public class SubOperationRequestDtoValidator : AbstractValidator<SubOperation.RequestDto>
        {
            public SubOperationRequestDtoValidator()
            {
                ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;

                RuleFor(x => x)
                    .NotNull().WithMessage("The request cannot be empty");

                RuleFor(x => x.Minuend)
                    .NotNull().WithMessage("Minuend is required");

                RuleFor(x => x.Subtrahend)
                   .NotNull().WithMessage("Subtrahend is required");
            }


        }
    }
}
