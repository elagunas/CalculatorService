using CalculatorService.Api.Contracts.DTOs;
using CalculatorService.Application.Journal.Interfaces;
using CalculatorService.Application.Shared;
using CalculatorService.Application.Shared.Interfaces;
using CalculatorService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CalculatorService.Application.Journal.Behaviours
{
    public class TrackingJournalOperationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ITrackingService _trackingService;
        private readonly IJournalOperationRepository _journalRepository;

        public TrackingJournalOperationBehavior(ITrackingService trackingService, IJournalOperationRepository journalRepository)
        {
            _trackingService = trackingService;
            _journalRepository = journalRepository;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            var trackingId = _trackingService.GetTrackingId();

            if (!string.IsNullOrEmpty(trackingId))
            {
                var baseResponse = response as IBaseResponseDto;
                var baserequest = request as IBaseCalculatorCommand;

                var journalOperation = new JournalOperation(baserequest.OperationName);
                var calculation = new Calculation(baserequest.GetOperation(), baseResponse.Result);

                journalOperation.AddCalculation(calculation);

                await _journalRepository.AddOrUpdate(trackingId,journalOperation);

            }

            return response;
        }
    }
}
