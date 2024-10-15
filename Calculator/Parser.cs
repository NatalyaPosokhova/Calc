using Calculator.Interfaces;
using System.Text;
using System.Text.RegularExpressions;
namespace Calculator
{
	public class Parser : IParser
	{
		public ExpressionIndexes GetInnerExpressionBorders(string exp)
		{
			var startIndex = 0;
			var endIndex = exp.Length - 1;
			bool isBraces = false;

			for (int i = 0; i < exp.Length; i++)
			{
				if (exp[i] == Constants.OpenedBrace)
				{
					startIndex = i;
					isBraces = true;
					continue;
				}

				if (exp[i] == Constants.ClosedBrace)
				{
					endIndex = i;
					break;
				}
			}

			return new ExpressionIndexes
			{
				StartIndex = startIndex,
				EndIndex = endIndex,
				IsBraces = isBraces
			};
		}

		public decimal GetFirstDigitFromPriorityOpExpression(string exp, int startIndex, int priorityOpIndex)
		{
			var digitStr = exp.Substring(startIndex, priorityOpIndex - startIndex);
			return decimal.Parse(digitStr);
		}

		public decimal GetSecondDigitFromPriorityOpExpression(string exp, int endIndex, int priorityOpIndex)
		{
			var digitStr = exp.Substring(priorityOpIndex + 1, endIndex - priorityOpIndex);
			return decimal.Parse(digitStr);
		}

		public ExpressionIndexes GetPriorityOpExpressionBorders(string exp, int priorityOpIndex)
		{
			int startIndex = 0;
			int endIndex = exp.Length - 1;

			var index = priorityOpIndex - 1;
			while (index >= 0 &&
				(Regex.IsMatch(exp[index].ToString(), @"\d") || index == 0))
			{
				startIndex = index;
				index--;
			}

			index = priorityOpIndex + 1;
			while (index < exp.Length && Regex.IsMatch(exp[index].ToString(), @"\d"))
			{
				endIndex = index;
				index++;
			}

			return new ExpressionIndexes { StartIndex = startIndex, EndIndex = endIndex };
		}

		public string ReplaceExpressionWithResult(string exp, ExpressionIndexes indexes, decimal result)
		{
			var sb = new StringBuilder();
			sb.Append(exp.Substring(0, indexes.StartIndex));
			sb.Append(result);
			sb.Append(exp.Substring(indexes.EndIndex + 1));

			return sb.ToString();
		}

		public string GetExpressionWithoutBraces(string exp, ExpressionIndexes innerExp)
		{
			var expWithoutBraces = innerExp.IsBraces ?
			   exp.Substring(innerExp.StartIndex + 1, innerExp.EndIndex - innerExp.StartIndex - 1) :
			   exp.Substring(innerExp.StartIndex, innerExp.EndIndex - innerExp.StartIndex + 1);
			return expWithoutBraces;
		}
	}
}
