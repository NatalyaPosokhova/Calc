using Calculator.Interfaces;

namespace Calculator.UnitTests
{
	public class PriorityQualifierTests
	{
		private IPriorityQualifier _priorityQualifier;

		[SetUp]
		public void Setup()
		{
			_priorityQualifier = new PriorityQualifier();
		}

		[TestCase("25+2-3*10-2-3/28", 6)]
		[TestCase("25+10-2", 2)]
		[TestCase("25/10-2*8", 2)]
		[TestCase("25", 0)]
		public void TryGetFirstHighPriorityOperationIndex_Success(string exp, int expectedIndex)
		{
			//Arrange
			//Act
			var actIndex = _priorityQualifier.GetFirstHighPriorityOperationIndex(exp);

			//Assert
			Assert.That(actIndex, Is.EqualTo(expectedIndex));
		}
	}
}
