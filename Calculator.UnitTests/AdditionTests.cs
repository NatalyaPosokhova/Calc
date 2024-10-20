using Calculator.Interfaces;
using Calculator.Operations;

namespace Calculator.UnitTests
{
	public class AdditionTests
	{
		private IOperation _additionOperation;

		[SetUp]
		public void Setup()
		{
			_additionOperation = new Addition();
		}

		[TestCase(-2, 3, 1)]
		[TestCase(2.5, 6.8, 9.3)]
		public void TryAdd_Success(decimal a, decimal b, decimal expected)
		{
			//Arrange
			//Act
			var act = _additionOperation.Execute(a, b);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}
	}
}
