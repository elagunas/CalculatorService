using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CalculatorService.Api.Contracts.DTOs
{
    public class DivOperation
    {
        public class RequestDto
        {
            public int Dividend { get; set; }

            public int Divisor { get; set; }
        }

        public class ResponseDto : IBaseResponseDto
        {
            public int Quotient { get; set; }

            public int Remainder { get; set; }

            [JsonIgnore]
            public string Result => $"Qt:{Quotient}, Rm: {Remainder}";
        }

    }
}
