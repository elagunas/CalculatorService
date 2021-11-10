using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalculatorService.Client
{
    class Program
    {
        private readonly static CalculatorServiceApiClient _calculatorServiceApiClient = new CalculatorServiceApiClient();
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to CalculatorClient App");
            bool showMenu = true;

            try
            {
                while (showMenu)
                {
                    showMenu = await MainMenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception was ocurred", ex.Message);
                Console.WriteLine("Run CalculatorClient App again");
            }
        }

        private static async Task<bool> MainMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Addition of two or more numeric operands.");
            Console.WriteLine("2) Subtraction of two numeric operands");
            Console.WriteLine("3) Multiply of two or more numeric operands");
            Console.WriteLine("4) Division of two numeric operands");
            Console.WriteLine("5) Square root of a numeric operand");
            Console.WriteLine("6) Query journal entries by TrackingId");
            Console.WriteLine("7) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    await ShowCalculationAddMenu();
                    return true;
                case "2":
                    await ShowCalculationSubMenu();
                    return true;
                case "3":
                    await ShowCalculationMultMenu();
                    return true;
                case "4":
                    await ShowCalculationDivMenu();
                    return true;
                case "5":
                    await ShowCalculationSqrtMenu();
                    return true;
                case "6":
                    await ShowCalculationQueryMenu();
                    return true;
                case "7":
                    return false;
                default:
                    return true;
            }
        }


        private static async Task ShowCalculationAddMenu()
        {
            Console.WriteLine("How many numeric operands do you want to use in sum?");
            var numericOperand = GetNumericInput();

            var numericOperands = new List<int>();
            for (int i = 1; i <= numericOperand; i++)
            {
                numericOperands.Add(GetNumericInput());
            }

            var trackingId = ShowTrackingMenu();

            Console.WriteLine($"Request Operation: ({string.Join('+', numericOperands)})");

            var result = await _calculatorServiceApiClient.AddOperation(numericOperands, trackingId);

            Console.WriteLine($"Result: {result}");
            
        }

        private static async Task ShowCalculationSubMenu()
        {
            Console.WriteLine("Enter minuend");
            var minuend = GetNumericInput();
            Console.WriteLine("Enter subtrahend");
            var subtrahend = GetNumericInput();

            var trackingId = ShowTrackingMenu();

            Console.WriteLine($"Request Operation: ({minuend} - {subtrahend})");

            var result = await _calculatorServiceApiClient.SubOperation(minuend,subtrahend,trackingId);

            Console.WriteLine($"Result: {result}");

        }

        private static async Task ShowCalculationDivMenu()
        {
            Console.WriteLine("Enter diviend");
            var diviend = GetNumericInput();
            Console.WriteLine("Enter divisor");
            var divisor = GetNumericInput();

            var trackingId = ShowTrackingMenu();

            Console.WriteLine($"Request Operation: ({diviend} / {divisor})");

            var result = await _calculatorServiceApiClient.DivOperation(diviend,divisor, trackingId);

            Console.WriteLine($"Result: {result}");

        }

        private static async Task ShowCalculationMultMenu()
        {
            Console.WriteLine("How many numeric operands do you want to use in multiplication?");
            var numericOperand = GetNumericInput();

            var numericOperands = new List<int>();
            for (int i = 1; i <= numericOperand; i++)
            {
                numericOperands.Add(GetNumericInput());
            }

            var trackingId = ShowTrackingMenu();

            Console.WriteLine($"Request Operation: ({string.Join('*', numericOperands)})");

            var result = await _calculatorServiceApiClient.MultOperation(numericOperands, trackingId);

            Console.WriteLine($"Result: {result}");

        }

        private static async Task ShowCalculationSqrtMenu()
        {
            Console.WriteLine("Enter a number");
            var number = GetNumericInput();

            var trackingId = ShowTrackingMenu();

            Console.WriteLine($"Request Operation: ( \u221A {number})");

            var result = await _calculatorServiceApiClient.SqrtOperation(number, trackingId);

            Console.WriteLine($"Result: {result}");

        }

        private static string ShowTrackingMenu()
        {
            Console.WriteLine("If you want to track the operation, enter some tracking Id");
            var trackingId = Console.ReadLine();
            return trackingId;
        }

        private static int GetNumericInput()
        {
            int number;

            var input = Console.ReadLine();

            while (!Int32.TryParse(input, out number))
            {
                Console.WriteLine("Not a valid number, try again.");

                input = Console.ReadLine();
            }

            return number;
        }


        private static async Task ShowCalculationQueryMenu()
        {
            Console.WriteLine("Enter a tracking Id, to show your stored operations");
            var trackingId = Console.ReadLine();

            var result = await _calculatorServiceApiClient.JournalQueryOperation(trackingId);

            Console.WriteLine($"Result: {result}");
        }

    }
}
