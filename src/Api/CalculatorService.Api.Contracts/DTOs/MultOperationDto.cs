using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CalculatorService.Api.Contracts.DTOs
{
    public static class MultOperation
    {

        public class RequestDto
        {
            public IEnumerable<int> Factors { get; set; }
        }

        public class ResponseDto : IBaseResponseDto
        {
            public int Product { get; set; }

            [JsonIgnore]
            public string Result => Product.ToString();
        }
    }
}
