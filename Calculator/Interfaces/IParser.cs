namespace Calculator.Interfaces
{
    public interface IParser
    {
        public Expression FindInnerExpression(string exp);
        public Expression GetPriorityOperationExpression(string exp, int priorityOpIndex);
	}
}
