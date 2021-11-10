using CalculatorService.Api.Contracts.DTOs;
using CalculatorService.Application.Shared.Interfaces;
using CalculatorService.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalculatorService.Application.Calculator.Commands
{
    public class CalculatorMultCommand : IBaseCalculatorCommand, IRequest<MultOperation.ResponseDto>
    {
        public MultOperation.RequestDto MultOperationRequestDto { get; set; }
        public string OperationName { get; private set; }

        public CalculatorMultCommand(MultOperation.RequestDto multOperationRequestDto)
        {
            MultOperationRequestDto = multOperationRequestDto;
            OperationName = OperationType.Mult.ToString();
        }

        public class CalculatorMultCommandHandler : IRequestHandler<CalculatorMultCommand, MultOperation.ResponseDto>
        {
            public Task<MultOperation.ResponseDto> Handle(CalculatorMultCommand request, CancellationToken cancellationToken)
            {
                var result = request.MultOperationRequestDto.Factors.Aggregate((total,current) => total * current);

                var response = new MultOperation.ResponseDto() { Product = result };

                return Task.FromResult(response);
            }
        }

        public string GetOperation()
        {
            return string.Join(" * ", MultOperationRequestDto.Factors);
        }
    }
}
