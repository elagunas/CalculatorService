using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService.Application.Journal.Validators
{
    public class JournalQueryValidator : AbstractValidator<Journal.Queries.JournalOperationQueryByJournalId>
    {
        public JournalQueryValidator()
        {
            RuleFor(x => x.QueryRequest.Id).
                NotEmpty().WithMessage("Id is required");
        }
    }
}
