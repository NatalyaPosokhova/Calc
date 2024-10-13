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

		[TestCase("(25+(2-3)*(10-2-3))",5 ,7)]
		[TestCase("(25+10-2)", 1, 7)]
		[TestCase("25+10-2", 0, 6)]
		public void GetInnerExpressionWithoutBraces_Success(string exp, int startIndex, int endIndex)
		{
			//Arrange
			//Act
			var act = _parser.GetInnerExpressionWithoutBraces(exp);

			//Assert
			Assert.That(act.StartIndex, Is.EqualTo(startIndex));
			Assert.That(act.EndIndex, Is.EqualTo(endIndex));
		}



		[TestCase("25+2-3*10-2-3/28", 6, 5, 8)]
		[TestCase("25+10-2", 2, 0, 4)]
		[TestCase("25/10-2*8", 2, 0, 4)]
		[TestCase("25", -1, 0, 1)]
		public void TryGetPriorityOperationExpression_Success(string exp, int priorityOpIndex, int startIndex, int endIndex)
		{
			//Arrange
			//Act
			var act = _parser.GetPriorityOperationExpression(exp, priorityOpIndex);

			//Assert
			Assert.That(act.StartIndex, Is.EqualTo(startIndex));
			Assert.That(act.EndIndex, Is.EqualTo(endIndex));
		}
	}
}
