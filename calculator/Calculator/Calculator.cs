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
