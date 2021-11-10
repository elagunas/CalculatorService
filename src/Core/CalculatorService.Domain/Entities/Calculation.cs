using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService.Domain.Entities
{
    public class Calculation
    {
        private string Operands;

        private string Result;

        public Calculation(string operands, string result)
        {
            Operands = operands;
            Result = result;
        }

        public string CalculationToStringFormat()
        {
            return $"{Operands} = {Result}";
        }
    }
}
