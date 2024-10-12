using System.Text.RegularExpressions;

namespace Calculator.Checkers
{
	internal class AllowedSymbolsChecker : Checker
	{
		private readonly static string allowedSymbols = @"\d|\+|-|\*|\/|\(|\)|\s";
		public AllowedSymbolsChecker(Checker Next) : base(Next)	{	}
		public override bool ValidateString(string exp)
		{
			if (!exp.All(ch => Regex.IsMatch(ch.ToString(), allowedSymbols)))
				return false;

			return base.ValidateString(exp);
		}

	}
}
