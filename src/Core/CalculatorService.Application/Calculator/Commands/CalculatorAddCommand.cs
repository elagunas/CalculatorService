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
    public class CalculatorAddCommand : IBaseCalculatorCommand, IRequest<AddOperation.ResponseDto>
    {
        public string OperationName { get; private set; }

        public AddOperation.RequestDto AddOperationRequestDto { get; set; }

        public CalculatorAddCommand(AddOperation.RequestDto addOperationRequestDto)
        {
            AddOperationRequestDto = addOperationRequestDto;
            OperationName = OperationType.Add.ToString();
        }

        public class CalcutatorAddCommandHandler : IRequestHandler<CalculatorAddCommand, AddOperation.ResponseDto>
        {
            public Task<AddOperation.ResponseDto> Handle(CalculatorAddCommand request, CancellationToken cancellationToken)
            {
                var result = request.AddOperationRequestDto.Addens.Sum(x => x);

                var response = new AddOperation.ResponseDto() { Sum = result };

                return Task.FromResult(response);
            }
        }

        public string GetOperation()
        {
            return string.Join(" + ", AddOperationRequestDto.Addens);
        }
    }
}
