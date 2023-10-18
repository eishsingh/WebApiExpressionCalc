using UL.Models;

namespace UL.Interfaces
{
    public interface IExpressionService
    {
       Task<double> CalculateResult(string expression);
    }
}
