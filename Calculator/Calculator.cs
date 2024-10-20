using Calculator.Exceptions;
using Calculator.Interfaces;

namespace Calculator
{
	public class Calculator(IParser _parser, IPriorityQualifier _priorityQualifier)
	{
		private static Dictionary<char, IOperation> _operations;
		public static Dictionary<char, IOperation> Operations => _operations;

		static Calculator()
		{
			var types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => typeof(IOperation).IsAssignableFrom(p) && !p.IsInterface);

			_operations = new Dictionary<char, IOperation>();
			foreach (var type in types)
			{
				var obj = (IOperation)Activator.CreateInstance(type);
				_operations.Add(obj.Symbol, obj);
			}
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
			_operations.TryGetValue(exp[priorityOpIndex], out var op);

			var firstDigit = _parser.GetFirstDigitFromPriorityOpExpression(exp, indexes.StartIndex, priorityOpIndex);
			var secondDigit = _parser.GetSecondDigitFromPriorityOpExpression(exp, indexes.EndIndex, priorityOpIndex);

			var res = op.Execute(firstDigit, secondDigit);

			if (indexes.StartIndex == 0 && indexes.EndIndex == exp.Length - 1)
				return res;

			var newExp = _parser.ReplaceExpressionWithResult(exp, indexes, res);
			return CalculateExpressionWithoutBraces(newExp);
		}
	}
}
