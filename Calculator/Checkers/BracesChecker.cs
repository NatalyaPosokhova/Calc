using System.Text.RegularExpressions;

namespace Calculator.Checkers
{
	internal class BracesChecker : Checker
	{
		private readonly static char openedBrace = '(';
		private readonly static char closedBrace = ')';
		public BracesChecker(Checker Next) : base(Next)	{	}
		public override bool ValidateString(string exp)
		{
			var stack = new Stack<char>();
			for (int i = 0; i < exp.Length; i++)
			{
				if (exp[i] == openedBrace)
					stack.Push(openedBrace);
				else if (exp[i] == closedBrace)
					stack.Pop();
			}

			if (stack.Count > 0)
				return false;

			return base.ValidateString(exp);
		}
	}
}
