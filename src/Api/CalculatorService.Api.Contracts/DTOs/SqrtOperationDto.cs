using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CalculatorService.Api.Contracts.DTOs
{
    public static class SqrtOperation
    {
        public class RequestDto
        {
            public int Number { get; set; }
        }

        public class ResponseDto : IBaseResponseDto
        {
            public double Square { get; set; }

            [JsonIgnore]
            public string Result => Square.ToString();

        }
    }
}
