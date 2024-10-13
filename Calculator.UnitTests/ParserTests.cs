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
	}
}
