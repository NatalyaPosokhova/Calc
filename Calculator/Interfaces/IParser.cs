namespace Calculator.Interfaces
{
    public interface IParser
    {
        public Expression FindInnerExpression(string exp);
    }
}
