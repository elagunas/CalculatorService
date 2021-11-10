using Xunit;
using CalculatorService.Domain;
using CalculatorService.Domain.Entities;

namespace Prime.UnitTests.Services
{
    public class CalculationTest
    {
        [Fact]
        public void IsCalculation_GeneratedCorrectly()
        {
            var calculation = new Calculation("5 + 2","7");

            string result = calculation.CalculationToStringFormat();

            Assert.Equal(result, "5 + 2 = 7");
        }
    }

    public class JournalOperationTest
    {
        [Fact]
        public void IsJournaOperation_GeneratedCorrectly()
        {
            var journalOperation = new JournalOperation("Sum");

            journalOperation.AddCalculation(new Calculation("5 + 2", "7"));

            string result = journalOperation.Calculation;

            Assert.Equal(result, "5 + 2 = 7");
        }
    }

}