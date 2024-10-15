using Calculator.Exceptions;
using Calculator.Interfaces;

namespace Calculator
{
	public class Calculator
	{
		private readonly IParser _parser;
		private readonly IOperationsPerformer _operationsPerformer;
		private readonly IPriorityQualifier _priorityQualifier;
		public Calculator(IParser parser, IOperationsPerformer operationsPerformer, IPriorityQualifier priorityQualifier)
		{
			_parser = parser;
			_operationsPerformer = operationsPerformer;
			_priorityQualifier = priorityQualifier;
		}
		public decimal CalculateExpression(string exp)
		{
			try
			{
				var innerExp = _parser.GetInnerExpressionBorders(exp);

				var expWithoutBraces = _parser.GetExpressionWithoutBraces(exp, innerExp);

				var res = CalculateExpressionWithoutBraces(expWithoutBraces);

				if (innerExp.StartIndex == 0 && innerExp.EndIndex == exp.Length - 1)
					return res;

				var newExp = _parser.ReplaceExpressionWithResult(exp, innerExp, res);
				return CalculateExpression(newExp);
			}
			catch (Exception ex)
			{
				throw new CannotCalculateExpressionException($"Возникла ошибка при вычислении выражения {exp}", ex);
			}
		}

		public decimal CalculateExpressionWithoutBraces(string exp)
		{
			var priorityOpIndex = _priorityQualifier.GetFirstHighPriorityOperationIndex(exp);
			if (priorityOpIndex == -1)
				return decimal.Parse(exp);

			var indexes = _parser.GetPriorityOpExpressionBorders(exp, priorityOpIndex);
			var op = GetOperation(exp[priorityOpIndex]);

			var firstDigit = _parser.GetFirstDigitFromPriorityOpExpression(exp, indexes.StartIndex, priorityOpIndex);
			var secondDigit = _parser.GetSecondDigitFromPriorityOpExpression(exp, indexes.EndIndex, priorityOpIndex);

			var res = op(firstDigit, secondDigit);

			if (indexes.StartIndex == 0 && indexes.EndIndex == exp.Length - 1)
				return res;

			var newExp = _parser.ReplaceExpressionWithResult(exp, indexes, res);
			return CalculateExpressionWithoutBraces(newExp);

		}

		private Func<decimal, decimal, decimal> GetOperation(char opSymbol)
		{
			switch (opSymbol)
			{
				case '+':
					return _operationsPerformer.Add;
				case '-':
					return _operationsPerformer.Substract;
				case '*':
					return _operationsPerformer.Multiply;
				case '/':
					return _operationsPerformer.Divide;
				default:
					throw new ArgumentException($"Для операции {opSymbol} нет реализации.");
			}
		}
	}
}
