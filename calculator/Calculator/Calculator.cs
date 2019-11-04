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

            var delimiters = GetDelimiters(formula);
            var numberStrings = formula.Split(delimiters.ToArray(), System.StringSplitOptions.RemoveEmptyEntries);

            var sum = GetSum(numberStrings);
            return sum.ToString();
        }

        // I'm making the assumption that we will always support the delimiters of ',' and '\n'
        // in every formula even if the formula has a custom delimiter
        private List<string> GetDelimiters(string formula)
        {
            var delimiters = new List<string> { ",", "\n" };

            if (formula.StartsWith("//") && formula[3] == '\n')
            {
                var customDelimiter = formula[2].ToString();
                delimiters.Add(customDelimiter);
            }
            else if (formula.StartsWith("//["))
            {
                var rightSquareBracketIndex = formula.IndexOf(']');
                var customDelimiter = formula.Substring(3, rightSquareBracketIndex - 3);
                delimiters.Add(customDelimiter);
            }

            return delimiters;
        }

        private float GetSum(string[] numberStrings)
        {
            var sum = 0f;

            var negativeNumbersEncountered = new List<float>();

            foreach (var numberString in numberStrings)
            {
                float.TryParse(numberString, out float numberFloat);
                if (numberFloat < 0)
                {
                    negativeNumbersEncountered.Add(numberFloat);
                }

                if (numberFloat > 1000)
                {
                    numberFloat = 0;
                }

                sum += numberFloat;
            }

            if (negativeNumbersEncountered.Count > 0)
            {
                ThrowNegativeNumbersException(negativeNumbersEncountered);
            }

            return sum;
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
