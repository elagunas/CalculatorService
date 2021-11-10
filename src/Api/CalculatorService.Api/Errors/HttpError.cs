using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CalculatorService.Api.Errors
{
    public class HttpError
    {
        [JsonIgnore]
        public int Code { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorStatus { get; set; }
        public string ErrorMessage { get; set; }
    }
}
