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
    public class CalculatorSubCommand : IBaseCalculatorCommand, IRequest<SubOperation.ResponseDto>
    {
        public SubOperation.RequestDto SubOperationRequestDto { get; set; }

        public string OperationName { get; private set; }

        public CalculatorSubCommand(SubOperation.RequestDto subOperationRequestDto)
        {
            SubOperationRequestDto = subOperationRequestDto;
            OperationName = OperationType.Sub.ToString();
        }

 

        public string GetOperation()
        {
            return $"{SubOperationRequestDto.Minuend} - {SubOperationRequestDto.Subtrahend}";
        }

        public class CalculatorSubCommandHandler : IRequestHandler<CalculatorSubCommand, SubOperation.ResponseDto>
        {
            public Task<SubOperation.ResponseDto> Handle(CalculatorSubCommand request, CancellationToken cancellationToken)
            {
                var result = request.SubOperationRequestDto.Minuend - request.SubOperationRequestDto.Subtrahend;

                var response = new SubOperation.ResponseDto() { Difference = result };

                return Task.FromResult(response);
            }
        }


    }
}
