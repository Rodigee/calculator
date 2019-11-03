using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public string CalculateFormula(string formula)
        {
            if (formula == null)
            {
                return "0";
            }

            var separtor = ',';

            var numberStrings = formula.Split(separtor);

            if(numberStrings.Length == 0)
            {
                return "0";
            }

            if (numberStrings.Length > 2)
            {
                throw (new ArgumentException("There can only be one comma in the formula"));
            }

            var firstString = numberStrings[0];
            int.TryParse(firstString, out int firstInt);

            if (numberStrings.Length == 1)
            {
                return firstInt.ToString();   
            }

            var secondString = numberStrings[1];
            int.TryParse(secondString, out int secondInt);

            var sum = firstInt + secondInt;

            return sum.ToString();
        }
    }
}
