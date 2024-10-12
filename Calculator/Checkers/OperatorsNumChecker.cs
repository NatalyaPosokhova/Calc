using System.Text.RegularExpressions;

namespace Calculator.Checkers
{
	internal class OperatorsNumChecker : Checker
	{
		private readonly static string wrongOperatorsNum = @"\+{2,}|-{2,}|\*{2,}|\/{2,}";
		public OperatorsNumChecker(Checker Next) : base(Next)	{	}
		public override bool ValidateString(string exp)
		{
			if (Regex.IsMatch(exp, wrongOperatorsNum))
				return false;

			return base.ValidateString(exp);
		}

	}
}
