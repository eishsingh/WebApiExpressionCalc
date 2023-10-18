using UL.Models;
using UL.Interfaces;

namespace UL.Services
{
    public class ExpressionService : IExpressionService
    {

        public async Task<double> CalculateResult(string inputExpression)
        {

            double result = 0;
            double currentNumber = 0;
            double previousNumber = 0;
            char mathOperator = '+';

            inputExpression = inputExpression.Replace(" ", "");

            for (var i = 0; i < inputExpression.Length; i++)
            {
                char c = inputExpression[i];

                // convert and build number 
                if (char.IsDigit(c))
                {
                    currentNumber = currentNumber * 10 + (c - '0');
                }

                //if maths operator then track and update result 
                if (IsOperator(c) || i == inputExpression.Length - 1)
                {
                    switch (mathOperator)
                    {
                        case '+':
                            result = result + previousNumber;
                            previousNumber = currentNumber;
                            break;
                        case '-':
                            result = result + previousNumber;
                            previousNumber = -currentNumber;
                            break;
                        case '*':
                            previousNumber = previousNumber * currentNumber;
                            break;
                        case '/':
                            if (currentNumber == 0)
                            {
                                throw new DivideByZeroException("Division by zero is not allowed.");
                            }
                            else
                            {
                                previousNumber = previousNumber / currentNumber;
                            }
                            break;
                        default:
                            throw new InvalidOperationException("Invalid operator: " + mathOperator);
                            break;
                    }

                    mathOperator = c;
                    currentNumber = 0;
                }
            }

            return result + previousNumber;
           
        }

        public static bool IsOperator(char c)
        {
            return "+-*/".Contains(c);
        }
    }
}
