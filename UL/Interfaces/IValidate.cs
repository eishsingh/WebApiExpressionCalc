namespace UL.Interfaces
{
    public interface IValidate
    {
        Boolean ValidExpression(string expression);

        Boolean ContainsDecimalPlace(string expression);
    }
}
