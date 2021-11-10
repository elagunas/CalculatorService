using CalculatorService.Api.Contracts.DTOs;
using CalculatorService.Application.Shared.Interfaces;
using CalculatorService.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace CalculatorService.Application.Calculator.Commands
{
    public class CalculatorSqrtCommand : IBaseCalculatorCommand, IRequest<SqrtOperation.ResponseDto>
    {
        public string OperationName { get; private set; }
        public SqrtOperation.RequestDto SqrtOperationRequestDto { get; set; }
        public CalculatorSqrtCommand(SqrtOperation.RequestDto sqrtOperationRequestDto)
        {
            SqrtOperationRequestDto = sqrtOperationRequestDto;
            OperationName = OperationType.Sqrt.ToString();
        }

        public string GetOperation()
        {
            return $" \u221A {SqrtOperationRequestDto.Number}";
        }

        public class CalculatorSubCommandHandler : IRequestHandler<CalculatorSqrtCommand, SqrtOperation.ResponseDto>
        {
            public Task<SqrtOperation.ResponseDto> Handle(CalculatorSqrtCommand request, CancellationToken cancellationToken)
            {
                var result = Math.Sqrt(request.SqrtOperationRequestDto.Number);

                var response = new SqrtOperation.ResponseDto() { Square = result };

                return Task.FromResult(response);
            }
        }
    }
}
