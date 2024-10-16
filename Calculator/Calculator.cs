using Calculator.Exceptions;
using Calculator.Interfaces;

namespace Calculator
{
	public class Calculator(IParser _parser, IOperationsPerformer _operationsPerformer, IPriorityQualifier _priorityQualifier)
	{		
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
			return opSymbol switch
			{
				'+' => _operationsPerformer.Add,
				'-' => _operationsPerformer.Substract,
				'*' => _operationsPerformer.Multiply,
				'/' => _operationsPerformer.Divide,
				_ => throw new ArgumentException($"Для операции {opSymbol} нет реализации."),
			};
		}
	}
}
