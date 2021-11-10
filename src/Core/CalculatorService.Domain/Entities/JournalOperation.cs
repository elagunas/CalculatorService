using CalculatorService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService.Domain.Entities
{
    public class JournalOperation
    {
        public string Operation { get; private set; }

        public string Calculation { get; private set; }

        public DateTime Date { get; private set; }

        public JournalOperation (string operation)
        {
            Operation = operation;
            Date = DateTime.Now;
        }

        public void AddCalculation(Calculation calculation)
        {
            Calculation = calculation.CalculationToStringFormat();
        }


    }
}
