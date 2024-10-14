using Calculator.Interfaces;
using NSubstitute;

namespace Calculator.UnitTests
{
	public class CalculatorTests
	{
		private Calculator _calculator;
		private IParser _parser;
		private IOperationsPerformer _operationsPerformer;
		private IPriorityQualifier _priorityQualifier;
		[SetUp]
		public void Setup()
		{
			_parser = Substitute.For<IParser>();
			_operationsPerformer = Substitute.For<IOperationsPerformer>();
			_priorityQualifier = Substitute.For<IPriorityQualifier>();
			_calculator = new Calculator(_parser, _operationsPerformer, _priorityQualifier);
		}

		[Test]
		public void TryCalculateExpressionWithoutBraces_Success()
		{
			//Arrange
			var exp = "25+2-3";
			var expected = 24;
			var priorityOpIndex = 2;
			var indexes = new ExpressionIndexes { StartIndex = 0, EndIndex = 3 };

			_priorityQualifier.GetFirstHighPriorityOperationIndex(exp).Returns(priorityOpIndex);
			_parser.GetPriorityOperationExpression(exp, priorityOpIndex).Returns(indexes);
			_operationsPerformer.Add(25, 2).Returns(27);

			var newExp = "27-3";
			_priorityQualifier.GetFirstHighPriorityOperationIndex(newExp).Returns(priorityOpIndex);
			_parser.GetPriorityOperationExpression(newExp, priorityOpIndex).Returns(indexes);
			_operationsPerformer.Substract(27, 3).Returns(24);

			//Act
			var act = _calculator.CalculateExpressionWithoutBraces(exp);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}
	}
}