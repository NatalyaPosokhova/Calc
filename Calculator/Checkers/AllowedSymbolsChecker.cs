using System.Text.RegularExpressions;

namespace Calculator.Checkers
{
	internal class AllowedSymbolsChecker : Checker
	{		
		public AllowedSymbolsChecker(Checker Next) : base(Next)	{	}
		public override bool ValidateString(string exp)
		{
			if (!exp.All(ch => Regex.IsMatch(ch.ToString(), Constants.AllowedSymbols)))
				return false;

			return base.ValidateString(exp);
		}

	}
}
