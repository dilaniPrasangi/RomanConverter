namespace XPS.RomanConverter.Helpers
{
    public static class RomanConverterHelper
    {
        private static readonly Dictionary<int, char> symbols = new Dictionary<int, char>
        {
            {1,'I'},{5,'V'},{10,'X'},{50,'L'},{100,'C'},{500,'D'},{1000,'M'}
        };

        public static string CovertToRoman(int number)
        {
            if (number > 0)
            {
                int units = GetPlaceValueCount(number, 1);
                int tens = GetPlaceValueCount(number, 10);
                int hundreds = GetPlaceValueCount(number, 100);
                int thousands = GetPlaceValueCount(number, 1000);

                string unitPart = units > 0 ? GetRomanNumber(units, symbols[5], symbols[1], 1, symbols[10]) : string.Empty;
                string tensPart = tens > 0 ? GetRomanNumber(tens, symbols[50], symbols[10], 10, symbols[100]) : string.Empty;
                string hundredsPart = hundreds > 0 ? GetRomanNumber(hundreds, symbols[500], symbols[100], 100, symbols[1000]) : string.Empty;
                string thousandsPart = new string(symbols[1000], thousands);

                return $"{thousandsPart}{hundredsPart}{tensPart}{unitPart}";

            }
            return string.Empty;
        }

        #region Private methods
        private static string GetRomanNumber(int number, char middleSymbol, char repeatSymbol, int placeValue, char nextSymbol)
        {
            number = number * placeValue;
            int middleNumber = placeValue * 10 / 2;

            if (number == middleNumber)
            {
                return middleSymbol.ToString();
            }

            string romanNumber = string.Empty;
            int repeatCount;
            char symbol;

            if (number > middleNumber)
            {
                romanNumber = middleSymbol.ToString();
                repeatCount = (number - middleNumber) / placeValue;
                symbol = nextSymbol;
            }
            else
            {
                repeatCount = number / placeValue;
                symbol = middleSymbol;
            }

            return repeatCount > 3 ? $"{repeatSymbol}{symbol}" : $"{romanNumber}{new string(repeatSymbol, repeatCount)}";
        }

        private static int GetPlaceValueCount(int number, int placeValue)
        {
            return (number / placeValue) % 10;
        }
        #endregion
    }
}
