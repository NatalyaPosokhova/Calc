﻿using Calculator.Interfaces;
using System.Text.RegularExpressions;
namespace Calculator
{
	public class Parser : IParser
	{
		public ExpressionIndexes GetExpressionWithoutBracesBorders(string exp)
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

			return new ExpressionIndexes
			{
				StartIndex = startIndex,
				EndIndex = endIndex
			};
		}

		public decimal GetFirstDigitFromPriorityOpExpression(string exp, int startIndex, int priorityOpIndex)
		{
			throw new NotImplementedException();
		}

		public ExpressionIndexes GetPriorityOpExpressionBorders(string exp, int priorityOpIndex)
		{
			int startIndex = 0;
			int endIndex = exp.Length - 1;

			var index = priorityOpIndex - 1;
			while (index >= 0 && Regex.IsMatch(exp[index].ToString(), @"\d"))
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

		public decimal GetSecondDigitFromPriorityOpExpression(string exp, int endIndex, int priorityOpIndex)
		{
			throw new NotImplementedException();
		}

		public string ReplaceExpressionWithResult(string exp, ExpressionIndexes indexes, decimal result)
		{
			throw new NotImplementedException();
		}
		
	}
}
