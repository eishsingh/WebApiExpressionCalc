using System.Text.RegularExpressions;
using UL.Interfaces;


namespace UL.Services
{
    public class ValidateService : IValidate
    {

        
        /// <summary>
        /// This method has a regex that must start with a number between 0-9
        /// operator characters +, -, *, /, ' '
        ///  not allowing two characters to be adjacent to each other
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool ValidExpression(string expression)
        {            
            Regex RgxUrl = new Regex("^(?!.*[+*-/]{2})[0-9][0-9+*-/ ]*$");
            return RgxUrl.IsMatch(expression);
        }

        public bool ContainsDecimalPlace(string expression)
        {
            return expression.Contains(".");
        }
    }
}
