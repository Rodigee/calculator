﻿using System;
using System.Collections.Generic;
using System.Linq;

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
            var numberStrings = formula.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var sum = GetSum(numberStrings);
            return sum.ToString();
        }

        private List<string> GetDelimiters(string formula)
        {
            // I'm making the assumption that we will always support the delimiters of ',' and '\n'
            // in every formula even if the formula has a custom delimiter
            var delimiters = new List<string> { ",", "\n" };

            if (formula.StartsWith("//") && formula[3] == '\n')
            {
                AddSingleCharacterCustomDelimiter(delimiters, formula);
            }
            else if (formula.StartsWith("//["))
            {
                AddMultiCharacterCustomDelimiters(delimiters, formula);
            }

            // We're listing the longer delimiters first so they take priority.
            // This gets around a bug that occurs when delimiters share characters
            delimiters = delimiters.OrderByDescending(x => x.Length).ToList();

            return delimiters;
        }

        private void AddSingleCharacterCustomDelimiter(List<string> delimiters, string formula)
        {
            var customDelimiter = formula[2].ToString();
            delimiters.Add(customDelimiter);
        }

        private void AddMultiCharacterCustomDelimiters (List<string> delimiters, string formula)
        {
            int leftSquareBracketIndex = 0;
            do
            {
                leftSquareBracketIndex = formula.IndexOf('[', leftSquareBracketIndex);
                var rightSquareBracketIndex = formula.IndexOf(']', leftSquareBracketIndex);
                if (rightSquareBracketIndex == -1)
                {
                    break;
                }

                var customDelimiterStartIndex = leftSquareBracketIndex + 1;
                var customDelimiterLength = rightSquareBracketIndex - customDelimiterStartIndex;
                var customDelimiter = formula.Substring(customDelimiterStartIndex, customDelimiterLength);
                delimiters.Add(customDelimiter);

                leftSquareBracketIndex = formula.IndexOf('[', rightSquareBracketIndex);
            } while (leftSquareBracketIndex != -1);
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
