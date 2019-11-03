using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public string CalculateSum(string formula)
        {
            if (formula == null)
            {
                return "0";
            }

            var separtor = ',';

            var numberStrings = formula.Split(separtor);

            var sum = 0;

            foreach(var numberString in numberStrings)
            {
                int.TryParse(numberString, out int numberInt);
                sum += numberInt;
            }

            return sum.ToString();
        }


    }
}
