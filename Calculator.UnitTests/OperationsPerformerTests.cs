using Calculator.Interfaces;

namespace Calculator.UnitTests
{
	public class OperationsPerformerTests
	{
		private IOperationsPerformer _operationsPerformer;

		[SetUp]
		public void Setup()
		{
			_operationsPerformer = new OperationsPerformer();
		}


		[TestCase(-2, 3, 1)]
		[TestCase(2.5, 6.8, 9.3)]
		public void TryAdd_Success(decimal a, decimal b, decimal expected)
		{
			//Arrange
			//Act
			var act = _operationsPerformer.Add(a, b);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}

		[TestCase(-2, 3, -5)]
		[TestCase(2.5, 6.8, -4.3)]
		public void TrySubstract_Success(decimal a, decimal b, decimal expected)
		{
			//Arrange
			//Act
			var act = _operationsPerformer.Substract(a, b);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}

		[TestCase(-2, 4, -0.5)]
		[TestCase(2.5, 5, 0.5)]
		public void TryDivide_Success(decimal a, decimal b, decimal expected)
		{
			//Arrange
			//Act
			var act = _operationsPerformer.Divide(a, b);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}

		[TestCase(-2, 3, -6)]
		[TestCase(2.5, 6.8, 17)]
		public void TryMultiply_Success(decimal a, decimal b, decimal expected)
		{
			//Arrange
			//Act
			var act = _operationsPerformer.Multiply(a, b);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}
	}
}
