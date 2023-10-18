using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Services;

namespace UL.Tests
{
    public class ExpressionTest
    {

        [Theory]
        [InlineData("4+5*2", 14)]
        [InlineData("4+5/2", 6.5)]
        [InlineData("4+5/2-1", 5.5)]
        [InlineData("2+3", 5)]
        [InlineData("7-4", 3)]
        [InlineData("6*8", 48)]
        [InlineData("15/3", 5)]
        [InlineData("10+5*3", 25)]
        [InlineData("20-6/2", 17)]
        [InlineData("4*3+8/2", 16)]
        [InlineData("9/3-1+7", 9)]
        [InlineData("12*2/4", 6)]
        [InlineData("7 / 2 * 3 - 1", 9.5)]
        [InlineData("15 / 4 + 2 * 3", 9.75)]
        [InlineData("9 / 2 - 1 + 4 * 2", 11.5)]
        [InlineData("8 / 3 * 2 - 5", 0.33333333333333304)]       
        [InlineData("2+4*3-5", 9)]
        [InlineData("30/2-4*2", 7)]
        [InlineData("5*2/2+3", 8)]
        [InlineData("6+7*3-4/2", 25)]
        [InlineData("15-9/3+6*2", 24)]
        [InlineData("8/2*4-3", 13)]
        [InlineData("17/4+2-4*15", -53.75)]
        [InlineData("14/7-2+5*2", 10)]
        [InlineData("10/5+3-2*2", 1)]
        [InlineData("6/3-1+3*2", 7)]
        [InlineData("18/9+1-5*2", -7)]
        [InlineData("15/5-1+4*2", 10)]
        [InlineData("10-5*3", -5)]
        [InlineData("3*4+8/2", 16)]
        [InlineData("7-2+6*3", 23)]
        [InlineData("9*3-7/2", 23.5)]
        [InlineData("222*2", 444)]
        [InlineData("6/3/2", 1)]
        [InlineData("12+4/2-6*3", -4)]
        [InlineData("5+7+8+9", 29)]
        public async Task GetResult_ShouldPass(string expressionInput, double expected)
        {
            ExpressionService expressionService = new();
            var actual = await expressionService.CalculateResult(expressionInput);
            Assert.Equal(expected, actual);
        }
    }
}
