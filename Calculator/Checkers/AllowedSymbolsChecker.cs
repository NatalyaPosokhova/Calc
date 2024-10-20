using Calculator.Interfaces;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator.Checkers
{
	internal class AllowedSymbolsChecker : Checker
	{
		public AllowedSymbolsChecker(Checker Next) : base(Next) { }
		public override bool ValidateString(string exp)
		{
			var sb = new StringBuilder(Constants.AllowedSymbols);
			var operations = Calculator.Operations.Values;

			foreach (var op in operations)
			{
				sb.Append('|');
				sb.Append('\\');
				sb.Append(op.Symbol);
			}

			if (!exp.All(ch => Regex.IsMatch(ch.ToString(), sb.ToString())))
				return false;

			return base.ValidateString(exp);
		}
	}
}
