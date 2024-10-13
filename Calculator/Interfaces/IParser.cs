namespace Calculator.Interfaces
{
    public interface IParser
    {
        public Expression GetInnerExpressionWithoutBraces(string exp);
        public Expression GetPriorityOperationExpression(string exp, int priorityOpIndex);
	}
}
