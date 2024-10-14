using Calculator.Exceptions;
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
		public void TryCalculateExpressionWithoutBraces_Add_Substract_Success()
		{
			//Arrange
			var exp = "25+2-3";
			var expected = 24;
			var priorityOpIndex = 2;
			var indexes = new ExpressionIndexes { StartIndex = 0, EndIndex = 3 };
			var intermRes = 27;
			var newExp = "27-3";
			var firstDigit = 25;
			var secondDigit = 2;

			_priorityQualifier.GetFirstHighPriorityOperationIndex(exp).Returns(priorityOpIndex);
			_parser.GetPriorityOpExpressionBorders(exp, priorityOpIndex).Returns(indexes);
			_parser.GetFirstDigitFromPriorityOpExpression(exp, indexes.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(exp, indexes.EndIndex, priorityOpIndex).Returns(secondDigit);
			_operationsPerformer.Add(firstDigit, secondDigit).Returns(intermRes);
			_parser.ReplaceExpressionWithResult(exp, indexes, intermRes).Returns(newExp);


			firstDigit = 27;
			secondDigit = 3;
			_priorityQualifier.GetFirstHighPriorityOperationIndex(newExp).Returns(priorityOpIndex);
			_parser.GetPriorityOpExpressionBorders(newExp, priorityOpIndex).Returns(indexes);
			_parser.GetFirstDigitFromPriorityOpExpression(newExp, indexes.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(newExp, indexes.EndIndex, priorityOpIndex).Returns(secondDigit);
			_operationsPerformer.Substract(firstDigit, secondDigit).Returns(expected);

			//Act
			var act = _calculator.CalculateExpressionWithoutBraces(exp);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}

		[Test]
		public void TryCalculateExpressionWithoutBraces_Add_Multiply_Success()
		{
			//Arrange
			var exp = "25+2*3";
			var expected = 31;
			var priorityOpIndex = 4;
			var indexes = new ExpressionIndexes { StartIndex = 3, EndIndex = 5 };
			var intermRes = 6;
			var newExp = "25+6";
			var firstDigit = 2;
			var secondDigit = 3;

			_priorityQualifier.GetFirstHighPriorityOperationIndex(exp).Returns(priorityOpIndex);
			_parser.GetPriorityOpExpressionBorders(exp, priorityOpIndex).Returns(indexes);
			_parser.GetFirstDigitFromPriorityOpExpression(exp, indexes.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(exp, indexes.EndIndex, priorityOpIndex).Returns(secondDigit);
			_operationsPerformer.Multiply(firstDigit, secondDigit).Returns(intermRes);
			_parser.ReplaceExpressionWithResult(exp, indexes, intermRes).Returns(newExp);

			priorityOpIndex = 2;
			firstDigit = 25;
			secondDigit = 6;
			indexes = new ExpressionIndexes { StartIndex = 0, EndIndex = 3 };
			_priorityQualifier.GetFirstHighPriorityOperationIndex(newExp).Returns(priorityOpIndex);
			_parser.GetPriorityOpExpressionBorders(newExp, priorityOpIndex).Returns(indexes);
			_parser.GetFirstDigitFromPriorityOpExpression(newExp, indexes.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(newExp, indexes.EndIndex, priorityOpIndex).Returns(secondDigit);
			_operationsPerformer.Add(firstDigit, secondDigit).Returns(expected);

			//Act
			var act = _calculator.CalculateExpressionWithoutBraces(exp);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}


		[Test]
		public void TryCalculateExpressionWithoutBraces_Divide_Multiply_Success()
		{
			//Arrange
			var exp = "22/2*3";
			var expected = 33;
			var priorityOpIndex = 2;
			var indexes = new ExpressionIndexes { StartIndex = 0, EndIndex = 3 };
			var intermRes = 11;
			var newExp = "11*3";
			var firstDigit = 22;
			var secondDigit = 2;

			_priorityQualifier.GetFirstHighPriorityOperationIndex(exp).Returns(priorityOpIndex);
			_parser.GetPriorityOpExpressionBorders(exp, priorityOpIndex).Returns(indexes);
			_parser.GetFirstDigitFromPriorityOpExpression(exp, indexes.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(exp, indexes.EndIndex, priorityOpIndex).Returns(secondDigit);
			_operationsPerformer.Divide(firstDigit, secondDigit).Returns(intermRes);
			_parser.ReplaceExpressionWithResult(exp, indexes, intermRes).Returns(newExp);

			firstDigit = 11;
			secondDigit = 3;
			_priorityQualifier.GetFirstHighPriorityOperationIndex(newExp).Returns(priorityOpIndex);
			_parser.GetPriorityOpExpressionBorders(newExp, priorityOpIndex).Returns(indexes);
			_parser.GetFirstDigitFromPriorityOpExpression(newExp, indexes.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(newExp, indexes.EndIndex, priorityOpIndex).Returns(secondDigit);
			_operationsPerformer.Multiply(firstDigit, secondDigit).Returns(expected);

			//Act
			var act = _calculator.CalculateExpressionWithoutBraces(exp);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}


		[Test]
		public void TryCalculateExpressionWithoutBraces_DivideByZeroException()
		{
			//Arrange
			var exp = "22+2/0";
			var expected = 33;
			var priorityOpIndex = 2;
			var indexes = new ExpressionIndexes { StartIndex = 0, EndIndex = 3 };
			var intermRes = 11;
			var firstDigit = 22;
			var secondDigit = 2;

			_priorityQualifier.GetFirstHighPriorityOperationIndex(exp).Returns(priorityOpIndex);
			_parser.GetPriorityOpExpressionBorders(exp, priorityOpIndex).Returns(indexes);
			_parser.GetFirstDigitFromPriorityOpExpression(exp, indexes.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(exp, indexes.EndIndex, priorityOpIndex).Returns(secondDigit);
			_operationsPerformer.Divide(firstDigit, secondDigit).Returns(intermRes);
			_operationsPerformer.When(x => x.Divide(firstDigit, secondDigit))
				.Do(x => { throw new System.DivideByZeroException("", null); });
		
			//Act
			//Assert
			Assert.Throws<CannotCalculateExpressionException>(() => _calculator.CalculateExpressionWithoutBraces(exp));
		}
	}
}