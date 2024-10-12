using Calculator.Interfaces;

namespace Calculator.UnitTests
{
    internal class ValidatorTests
	{
		private IValidator _validator;

		[SetUp]
		public void Setup()
		{
			_validator = new Validator();
		}

		[TestCase("-1*2/3", true)]
		[TestCase("10+(2-3)", true)]
		[TestCase("(25+2-3)*(10-2)", true)]
		[TestCase("1+(2/3(", false)]
		[TestCase("1+(2/3", false)]
		[TestCase("1", true)]
		[TestCase("(25 + 2 - 3) * (10 - 2)", true)]
		[TestCase("(25 + 2 - 3)rrr * (10 - 2eee)", false)]
		[TestCase("1--3+2", false)]
		public void TryValidateExpressionShouldBeExpected(string enteredStr, bool expected)
		{
			//Arrange
			//Act
			var act = _validator.ValidateExpression(enteredStr);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}
	}
}
