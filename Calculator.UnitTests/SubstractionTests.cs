using Calculator.Interfaces;
using Calculator.Operations;

namespace Calculator.UnitTests
{
	public class SubstractionTests
	{
		private IOperation _substractionOperation;

		[SetUp]
		public void Setup()
		{
			_substractionOperation = new Substraction();
		}

		[TestCase(-2, 3, -5)]
		[TestCase(2.5, 6.8, -4.3)]
		public void TrySubstract_Success(decimal a, decimal b, decimal expected)
		{
			//Arrange
			//Act
			var act = _substractionOperation.Execute(a, b);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}
	}
}
