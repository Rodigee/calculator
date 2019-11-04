using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var Calculator = new Calculator.Calculator();

            do
            {
                Console.WriteLine("Please enter your formula:");
                var formula = Console.ReadLine();
                var result = Calculator.CalculateSum(formula);
                Console.WriteLine("Result:");
                Console.WriteLine(result);
            } while (true);
            
        }
    }
}
