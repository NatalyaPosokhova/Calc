using Calculator.Interfaces;
using Calculator.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.UnitTests
{
	public class ExponentiationTests
	{
		private IOperation _exponentiationOperation;

		[SetUp]
		public void Setup()
		{
			_exponentiationOperation = new Exponentiation();
		}

		[TestCase(-2, 3, -8)]
		[TestCase(7.1, 2, 50.41)]
		public void TryExponentiation_Success(decimal a, decimal b, decimal expected)
		{
			//Arrange
			//Act
			var act = _exponentiationOperation.Execute(a, b);

			//Assert
			Assert.That(act, Is.EqualTo(expected));
		}
	}
}
