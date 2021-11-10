using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CalculatorService.Api.Contracts.DTOs
{
    public static class AddOperation
    {
        public class RequestDto
        {
            public IEnumerable<int> Addens { get; set; } 
        }

        public class ResponseDto : IBaseResponseDto
        {
            public int Sum { get; set; }

            [JsonIgnore]
            public string Result => Sum.ToString();

        }
    }
}
