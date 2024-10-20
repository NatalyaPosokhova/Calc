using Calculator.Exceptions;
using Calculator.Interfaces;
using NSubstitute;

namespace Calculator.UnitTests
{
	public class CalculatorTests
	{
		private Calculator _calculator;
		private IParser _parser;
		private IPriorityQualifier _priorityQualifier;
		[SetUp]
		public void Setup()
		{
			_parser = Substitute.For<IParser>();
			_priorityQualifier = Substitute.For<IPriorityQualifier>();
			_calculator = new Calculator(_parser, _priorityQualifier);
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
			_parser.ReplaceExpressionWithResult(exp, indexes, intermRes).Returns(newExp);


			firstDigit = 27;
			secondDigit = 3;
			_priorityQualifier.GetFirstHighPriorityOperationIndex(newExp).Returns(priorityOpIndex);
			_parser.GetPriorityOpExpressionBorders(newExp, priorityOpIndex).Returns(indexes);
			_parser.GetFirstDigitFromPriorityOpExpression(newExp, indexes.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(newExp, indexes.EndIndex, priorityOpIndex).Returns(secondDigit);

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
			_parser.ReplaceExpressionWithResult(exp, indexes, intermRes).Returns(newExp);

			priorityOpIndex = 2;
			firstDigit = 25;
			secondDigit = 6;
			indexes = new ExpressionIndexes { StartIndex = 0, EndIndex = 3 };
			_priorityQualifier.GetFirstHighPriorityOperationIndex(newExp).Returns(priorityOpIndex);
			_parser.GetPriorityOpExpressionBorders(newExp, priorityOpIndex).Returns(indexes);
			_parser.GetFirstDigitFromPriorityOpExpression(newExp, indexes.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(newExp, indexes.EndIndex, priorityOpIndex).Returns(secondDigit);

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
			_parser.ReplaceExpressionWithResult(exp, indexes, intermRes).Returns(newExp);

			firstDigit = 11;
			secondDigit = 3;
			_priorityQualifier.GetFirstHighPriorityOperationIndex(newExp).Returns(priorityOpIndex);
			_parser.GetPriorityOpExpressionBorders(newExp, priorityOpIndex).Returns(indexes);
			_parser.GetFirstDigitFromPriorityOpExpression(newExp, indexes.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(newExp, indexes.EndIndex, priorityOpIndex).Returns(secondDigit);

			//Act
			var act = _calculator.CalculateExpressionWithoutBraces(exp);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}

		[Test]
		public void TryCalculateExpression_Add_Multiply_Success()
		{
			//Arrange
			var exp = "25+2*(3+6)";
			var expected = 43;
			var priorityOpIndex = 1;
			var indexes1 = new ExpressionIndexes { StartIndex = 5, EndIndex = 9, IsBraces = true };
			var expWithoutBraces = "3+6";

			_parser.GetInnerExpressionBorders(exp).Returns(indexes1);
			_parser.GetExpressionWithoutBraces(exp, indexes1).Returns(expWithoutBraces);
			_priorityQualifier.GetFirstHighPriorityOperationIndex(expWithoutBraces).Returns(priorityOpIndex);

			var firstDigit = 3;
			var secondDigit = 6;
			var intermRes = 9;
			var newExp = "9";
			var indexes2 = new ExpressionIndexes { StartIndex = 0, EndIndex = 2 };
			_parser.GetPriorityOpExpressionBorders(expWithoutBraces, priorityOpIndex).Returns(indexes2);
			_parser.GetFirstDigitFromPriorityOpExpression(expWithoutBraces, indexes2.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(expWithoutBraces, indexes2.EndIndex, priorityOpIndex).Returns(secondDigit);

			newExp = "25+2*9";
			priorityOpIndex = 4;
			_parser.ReplaceExpressionWithResult(exp, indexes1, intermRes).Returns(newExp);

			var indexes3 = new ExpressionIndexes { StartIndex = 0, EndIndex = 5};
			_parser.GetInnerExpressionBorders(newExp).Returns(indexes3);
			_parser.GetExpressionWithoutBraces(newExp, indexes3).Returns(newExp);
			_priorityQualifier.GetFirstHighPriorityOperationIndex(newExp).Returns(priorityOpIndex);

			var indexes4 = new ExpressionIndexes { StartIndex = 3, EndIndex = 5 };
			firstDigit = 2;
			secondDigit = 9;
			intermRes = 18;
			_parser.GetPriorityOpExpressionBorders(newExp, priorityOpIndex).Returns(indexes4);
			_parser.GetFirstDigitFromPriorityOpExpression(newExp, indexes4.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(newExp, indexes4.EndIndex, priorityOpIndex).Returns(secondDigit);

			var newExp2 = "25+18";
			_parser.ReplaceExpressionWithResult(newExp, indexes4, intermRes).Returns(newExp2);
			
			priorityOpIndex = 2;
			firstDigit = 25;
			secondDigit = 18;
			var indexes5 = new ExpressionIndexes { StartIndex = 0, EndIndex = 4 };			
			_priorityQualifier.GetFirstHighPriorityOperationIndex(newExp2).Returns(priorityOpIndex);
			_parser.GetPriorityOpExpressionBorders(newExp2, priorityOpIndex).Returns(indexes5);
			_parser.GetFirstDigitFromPriorityOpExpression(newExp2, indexes5.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(newExp2, indexes5.EndIndex, priorityOpIndex).Returns(secondDigit);

			//Act
			var act = _calculator.CalculateExpression(exp);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}

		[Test]
		public void TryCalculateExpression_DivideByZeroException()
		{
			//Arrange
			var exp = "22+2/0";
			var priorityOpIndex = 4;
			var indexes = new ExpressionIndexes { StartIndex = 3, EndIndex = 5 };

			_parser.GetInnerExpressionBorders(exp).Returns(indexes);
			_parser.GetExpressionWithoutBraces(exp, indexes).Returns(exp);
			_priorityQualifier.GetFirstHighPriorityOperationIndex(exp).Returns(priorityOpIndex);

			var firstDigit = 2;
			var secondDigit = 0;
			var indexes2 = new ExpressionIndexes { StartIndex = 0, EndIndex = 2 };
			_parser.GetPriorityOpExpressionBorders(exp, priorityOpIndex).Returns(indexes2);
			_parser.GetFirstDigitFromPriorityOpExpression(exp, indexes2.StartIndex, priorityOpIndex).Returns(firstDigit);
			_parser.GetSecondDigitFromPriorityOpExpression(exp, indexes2.EndIndex, priorityOpIndex).Returns(secondDigit);

			//Act
			//Assert
			Assert.Throws<CannotCalculateExpressionException>(() => _calculator.CalculateExpression(exp));
		}
	}
}