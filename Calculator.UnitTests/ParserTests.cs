using Calculator.Interfaces;

namespace Calculator.UnitTests
{
	public class ParserTests
	{
		private IParser _parser;

		[SetUp]
		public void Setup()
		{
			_parser = new Parser();
		}

		[TestCase("(25+(2-3)*(10-2-3))",4 ,8)]
		[TestCase("(25+10-2)", 0, 8)]
		[TestCase("25+10-2", 0, 6)]
		public void TryGetExpressionWithoutBracesBorders_Success(string exp, int startIndex, int endIndex)
		{
			//Arrange
			//Act
			var act = _parser.GetExpressionWithoutBracesBorders(exp);

			//Assert
			Assert.That(act.StartIndex, Is.EqualTo(startIndex));
			Assert.That(act.EndIndex, Is.EqualTo(endIndex));
		}

 		[TestCase("25+2-3*10-2-3/28", 6, 5, 8)]
		[TestCase("25+10-2", 2, 0, 4)]
		[TestCase("25/10-2*8", 2, 0, 4)]
		[TestCase("25", -1, 0, 1)]
		[TestCase("-25+2-2", 3, 0, 4)]
		public void TryGetPriorityOpExpressionBorders_Success(string exp, int priorityOpIndex, int startIndex, int endIndex)
		{
			//Arrange
			//Act
			var act = _parser.GetPriorityOpExpressionBorders(exp, priorityOpIndex);

			//Assert
			Assert.That(act.StartIndex, Is.EqualTo(startIndex));
			Assert.That(act.EndIndex, Is.EqualTo(endIndex));
		}

		[TestCase("25+2-3*10-2-3/28", 6, 5, 3)]
		[TestCase("25+10-2", 2, 0, 25)]
		[TestCase("25/10-2*8", 2, 0, 25)]
		[TestCase("-25/10-2*8", 3, 0, -25)]
		public void TryGetFirstDigitFromPriorityOpExpression_Success(string exp, int priorityOpIndex, int startIndex, decimal expected)
		{
			//Arrange
			//Act
			var act = _parser.GetFirstDigitFromPriorityOpExpression(exp, startIndex, priorityOpIndex);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}

		[TestCase("25+2-3*10-2-3/28", 6, 8, 10)]
		[TestCase("25+10-2", 2, 4, 10)]
		[TestCase("25/10-2*8", 2, 4, 10)]
		[TestCase("-25/10-2*8", 3, 5, 10)]
		public void TryGetSecondDigitFromPriorityOpExpression_Success(string exp, int priorityOpIndex, int endIndex, decimal expected)
		{
			//Arrange
			//Act
			var act = _parser.GetSecondDigitFromPriorityOpExpression(exp, endIndex, priorityOpIndex);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}

		[TestCase("25+2-3*10-2-3/28", 5, 8, 30, "25+2-30-2-3/28")]
		[TestCase("25+10-2", 0, 4, 35, "35-2")]
		[TestCase("20/10-2*8", 0, 4, 2, "2-2*8")]
		[TestCase("-25+2-2", 0, 4, -23, "-23-2")]
		[TestCase("25+2-3*(10-2)-3/28", 7, 12, 8, "25+2-3*8-3/28")]
		public void TryReplaceExpressionWithResult_Success(string exp, int startIndex, int endIndex, decimal result, string expected)
		{
			//Arrange
			var indexes = new ExpressionIndexes { StartIndex = startIndex, EndIndex = endIndex };
			//Act
			var act = _parser.ReplaceExpressionWithResult(exp, indexes, result);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}
	}
}
