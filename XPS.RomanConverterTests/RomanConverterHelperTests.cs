using XPS.RomanConverter.Helpers;

namespace XPS.RomanConverterTests
{
    public class RomanConverterHelperTests
    {
        [Theory]
        [InlineData(-100, "")]
        [InlineData(0, "")]
        [InlineData(1, "I")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(14, "XIV")]
        [InlineData(50, "L")]
        [InlineData(80, "LXXX")]
        [InlineData(90, "XC")]
        [InlineData(100, "C")]
        [InlineData(254, "CCLIV")]
        [InlineData(469, "CDLXIX")]
        [InlineData(500, "D")]
        [InlineData(720, "DCCXX")]
        [InlineData(999, "CMXCIX")]
        [InlineData(1000, "M")]
        [InlineData(1500, "MD")]
        [InlineData(1589, "MDLXXXIX")]
        [InlineData(1670, "MDCLXX")]
        [InlineData(2000, "MM")]
        public void CovertToRomanTests(int number, string romanNumber)
        {
            string result = RomanConverterHelper.CovertToRoman(number);
            Assert.Equal(romanNumber, result);
        }
    }
}