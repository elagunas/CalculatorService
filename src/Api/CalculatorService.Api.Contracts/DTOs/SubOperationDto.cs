using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CalculatorService.Api.Contracts.DTOs
{
    public static class SubOperation
    {
        public class RequestDto
        {
            public int Minuend { get; set; }

            public int Subtrahend { get; set; }
        }

        public class ResponseDto : IBaseResponseDto
        {
            public int Difference { get; set; }

            [JsonIgnore]
            public string Result => Difference.ToString();

        }

    }
}
