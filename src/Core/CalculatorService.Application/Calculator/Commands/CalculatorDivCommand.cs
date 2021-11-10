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
    public class CalculatorDivCommand : IBaseCalculatorCommand, IRequest<DivOperation.ResponseDto>
    {
        public DivOperation.RequestDto DivOperationRequestDto { get; set; }
        public string OperationName { get; private set; }

        public CalculatorDivCommand(DivOperation.RequestDto divOperationRequestDto)
        {
            DivOperationRequestDto = divOperationRequestDto;
            OperationName = OperationType.Div.ToString();

        }

        public string GetOperation()
        {
            return $" {DivOperationRequestDto.Dividend} / {DivOperationRequestDto.Divisor}";
        }

        public class CalculatorDivCommandHandler : IRequestHandler<CalculatorDivCommand, DivOperation.ResponseDto>
        {
            public Task<DivOperation.ResponseDto> Handle(CalculatorDivCommand request, CancellationToken cancellationToken)
            {
                int remainder;
                int quotient = Math.DivRem(request.DivOperationRequestDto.Dividend, request.DivOperationRequestDto.Divisor, out remainder);

                var result =new DivOperation.ResponseDto() { Quotient = quotient, Remainder = remainder };
                return Task.FromResult(result);
            }
        }


    }
}
