namespace Calculator.Interfaces
{
    public interface IParser
    {
        public ExpressionIndexes GetInnerExpressionWithoutBraces(string exp);
        public ExpressionIndexes GetPriorityOperationExpression(string exp, int priorityOpIndex);
	}
}
