using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Services;

namespace UL.Tests
{
    public class ValidateTest
    {

        [Theory]
        [InlineData("2+3", true)]
        [InlineData("17 / 5 + 1 - 3 * 2", true)]
        [InlineData("17/4+2-4*15", true)]
        [InlineData("17 /4+2- 4*15", true)]
        public void validExpression_shouldPass(string input, bool expected)
        {
            ValidateService validateService = new();
            var actual = validateService.ValidExpression(input);
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("", false)]
        [InlineData("12/abc", false)]
        [InlineData("12+-32", false)]
        [InlineData("++++++", false)]
        [InlineData("*", false)]
        [InlineData("abc + asd", false)]
        [InlineData("£5 + £2", false)]
        public void validExpression_shouldFail(string input, bool expected)
        {
            ValidateService validateService = new();
            var actual = validateService.ValidExpression(input);
            Assert.Equal(expected, actual);
        }

    }
}
