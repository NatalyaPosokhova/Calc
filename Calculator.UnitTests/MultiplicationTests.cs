using Calculator.Interfaces;
using Calculator.Operations;

namespace Calculator.UnitTests
{
	public class MultiplicationTests
	{
		private IOperation _multiplicationOperation;

		[SetUp]
		public void Setup()
		{
			_multiplicationOperation = new Multiplication();
		}

		[TestCase(-2, 3, -6)]
		[TestCase(2.5, 6.8, 17)]
		public void TryMultiply_Success(decimal a, decimal b, decimal expected)
		{
			//Arrange
			//Act
			var act = _multiplicationOperation.Execute(a, b);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}
	}
}
