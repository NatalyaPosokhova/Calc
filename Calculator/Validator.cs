using Calculator.Checkers;
using Calculator.Interfaces;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
	public class Validator : IValidator
	{

		public bool ValidateExpression(string exp)
		{
			var operatorsNumChecker = new OperatorsNumChecker(null);
			var bracesChecker = new BracesChecker(operatorsNumChecker);
			var allowedSymbolsChecker = new AllowedSymbolsChecker(bracesChecker);
			return allowedSymbolsChecker.ValidateString(exp);
		}
	}
}
