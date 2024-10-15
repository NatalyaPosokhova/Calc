using Calculator.Checkers;

namespace Calculator
{
	public static class Validator
	{
		public static bool ValidateExpression(string? exp)
		{
			if (exp == null)
				return false;

			var operatorsNumChecker = new OperatorsNumChecker(null);
			var bracesChecker = new BracesChecker(operatorsNumChecker);
			var allowedSymbolsChecker = new AllowedSymbolsChecker(bracesChecker);
			return allowedSymbolsChecker.ValidateString(exp);
		}
	}
}
