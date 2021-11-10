using CalculatorService.Api.Contracts.DTOs;
using CalculatorService.Application.Calculator.Commands;
using CalculatorService.Application.Journal.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorService.Api.Controllers
{
    public class JournalController : BaseApiController
    {
        public JournalController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("query")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(QueryJournalOperation.ResponseDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<QueryJournalOperation.ResponseDto>> Query([FromBody] QueryJournalOperation.RequestDto journalQueryDto)
        {
            var result = await _mediator.Send(new JournalOperationQueryByJournalId(journalQueryDto));

            if (result.Operations == null || result.Operations.Count() == 0)
                return NotFound();

            return Ok(result);
        }
    }
}
