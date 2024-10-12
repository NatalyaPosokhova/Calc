using System.Text.RegularExpressions;

namespace Calculator.Checkers
{
	internal class BracesChecker : Checker
	{
		public BracesChecker(Checker Next) : base(Next)	{	}
		public override bool ValidateString(string exp)
		{
			var stack = new Stack<char>();
			for (int i = 0; i < exp.Length; i++)
			{
				if (exp[i] == Constants.OpenedBrace)
					stack.Push(Constants.OpenedBrace);
				else if (exp[i] == Constants.ClosedBrace)
					stack.Pop();
			}

			if (stack.Count > 0)
				return false;

			return base.ValidateString(exp);
		}
	}
}
