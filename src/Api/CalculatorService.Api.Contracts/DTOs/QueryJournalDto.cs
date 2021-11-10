using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService.Api.Contracts.DTOs
{
    public static class QueryJournalOperation
    {
        public class RequestDto 
        { 
            public string Id { get; set; }
        
        }

        public class ResponseDto
        {
            public IEnumerable<OperationDto> Operations { get; set; }
        }

    }


    public class OperationDto
    {
        public string Operation { get; set; }

        public string Calculation { get; set; }

        public DateTime Date { get; set; }
    }
}
