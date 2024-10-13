using Calculator.Interfaces;
namespace Calculator
{
	public class Parser : IParser
	{
		public Expression FindInnerExpression(string exp)
		{
			var startIndex = 0;
			var endIndex = exp.Length - 1;

			for (int i = 0; i < exp.Length; i++)
			{
				if (exp[i] == Constants.OpenedBrace)
				{
					startIndex = i + 1;
					continue;
				}

				if (exp[i] == Constants.ClosedBrace)
				{
					endIndex = i - 1;
					break;
				}
			}

			return new Expression
			{
				StartIndex = startIndex,
				EndIndex = endIndex
			};
		}

		public Expression GetPriorityOperationExpression(string exp, int priorityOpIndex)
		{
			throw new NotImplementedException();
		}
	}
}
