namespace Calculator.Interfaces
{
    public interface IParser
    {
        public ExpressionIndexes GetInnerExpressionBorders(string exp);
        public ExpressionIndexes GetPriorityOpExpressionBorders(string exp, int priorityOpIndex);
		public string ReplaceExpressionWithResult(string exp, ExpressionIndexes indexes, decimal result);
        public decimal GetFirstDigitFromPriorityOpExpression(string exp, int startIndex, int priorityOpIndex);
        public decimal GetSecondDigitFromPriorityOpExpression(string exp, int endIndex, int priorityOpIndex);
        public string GetExpressionWithoutBraces(string exp, ExpressionIndexes innerExp);
	}
}
