using System;
using System.Collections.Generic;

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

            char[] separators = { ',', '\n' };

            var numberStrings = formula.Split(separators);

            var sum = 0f;

            var negativeNumbersEncountered = new List<float>();

            foreach(var numberString in numberStrings)
            {
                float.TryParse(numberString, out float numberFloat);
                if(numberFloat < 0)
                {
                    negativeNumbersEncountered.Add(numberFloat);
                }

                if(numberFloat > 1000)
                {
                    numberFloat = 0;
                }

                sum += numberFloat;
            }

            if(negativeNumbersEncountered.Count > 0)
            {
                ThrowNegativeNumbersException(negativeNumbersEncountered);
            }

            return sum.ToString();
        }

        private void ThrowNegativeNumbersException(List<float> negativeNumbersEncountered)
        {
            var negativeNumbersFoundAsString = string.Empty;

            foreach (var negativeNumberFound in negativeNumbersEncountered)
            {
                negativeNumbersFoundAsString = negativeNumbersFoundAsString + " " + negativeNumberFound;
            }

            throw new ArgumentException(string.Format("Formula cannot use negative numbers. Negative in formula are: {0}", negativeNumbersFoundAsString));
        }


    }
}
