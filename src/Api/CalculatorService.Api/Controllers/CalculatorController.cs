using CalculatorService.Api.Contracts.DTOs;
using CalculatorService.Application.Calculator.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorService.Api.Controllers
{
    public class CalculatorController : BaseApiController
    {
        public CalculatorController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(AddOperation.ResponseDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<AddOperation.ResponseDto>> Add([FromBody] AddOperation.RequestDto addOperationRequestDto)
        {
            return await _mediator.Send(new CalculatorAddCommand(addOperationRequestDto));
        }

        [HttpPost("sub")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(SubOperation.ResponseDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<SubOperation.ResponseDto>> Sub([FromBody] SubOperation.RequestDto subOperationRequestDto)
        {
            return await _mediator.Send(new CalculatorSubCommand(subOperationRequestDto));
        }

        [HttpPost("mult")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(MultOperation.ResponseDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<MultOperation.ResponseDto>> Mult([FromBody] MultOperation.RequestDto multOperationRequestDto)
        {
            return await _mediator.Send(new CalculatorMultCommand(multOperationRequestDto));
        }

        [HttpPost("div")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(DivOperation.ResponseDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<DivOperation.ResponseDto>> Div([FromBody] DivOperation.RequestDto divOperationRequestDto)
        {
            return await _mediator.Send(new CalculatorDivCommand(divOperationRequestDto));
        }

        [HttpPost("sqrt")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(SqrtOperation.ResponseDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<SqrtOperation.ResponseDto>> Div([FromBody] SqrtOperation.RequestDto sqrtOperationRequestDto)
        {
            return await _mediator.Send(new CalculatorSqrtCommand(sqrtOperationRequestDto));
        }
    }
}
