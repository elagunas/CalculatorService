using AutoMapper;
using CalculatorService.Api.Contracts.DTOs;
using CalculatorService.Application.Journal.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CalculatorService.Application.Journal.Queries
{
    public class JournalOperationQueryByJournalId : IRequest<QueryJournalOperation.ResponseDto>
    {
        internal readonly QueryJournalOperation.RequestDto QueryRequest;

        public JournalOperationQueryByJournalId(QueryJournalOperation.RequestDto queryRequest)
        {
            QueryRequest = queryRequest;
        }
        public class JournalOperationQueryByJournalIdHandler : IRequestHandler<JournalOperationQueryByJournalId, QueryJournalOperation.ResponseDto>
        {
            private readonly IJournalOperationRepository _journalRepositoy;
            private readonly IMapper _mapper;

            public JournalOperationQueryByJournalIdHandler(IJournalOperationRepository journalRepositoy, IMapper mapper)
            {
                _journalRepositoy = journalRepositoy;
                _mapper = mapper;
            }

            public async Task<QueryJournalOperation.ResponseDto> Handle(JournalOperationQueryByJournalId request, CancellationToken cancellationToken)
            {
                var operations = await _journalRepositoy.Get(request.QueryRequest.Id);

                var operationsDto = _mapper.Map<IEnumerable<OperationDto>>(operations);

                var result = new QueryJournalOperation.ResponseDto() { Operations = operationsDto };

                return result;
            }
        }
    }
}
