using Calculator.Interfaces;
using Calculator.Operations;

namespace Calculator.UnitTests
{
	public class DivisionTests
	{
		private IOperation _divisionOperation;

		[SetUp]
		public void Setup()
		{
			_divisionOperation = new Division();
		}

		[TestCase(-2, 4, -0.5)]
		[TestCase(2.5, 5, 0.5)]
		public void TryDivide_Success(decimal a, decimal b, decimal expected)
		{
			//Arrange
			//Act
			var act = _divisionOperation.Execute(a, b);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}
	}
}
