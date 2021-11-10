using CalculatorService.Application.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorService.Api.Services
{
    public class EviTrackingService : ITrackingService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string HeaderTracking = "X-Evi-Tracking-Id";

        public EviTrackingService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public string GetTrackingId() 
        {
            var headerTrackingValue = string.Empty;

            if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue(HeaderTracking, out var headerValue))
            {
                headerTrackingValue = headerValue;
            }

            return headerTrackingValue;
        }
    }
}
