using Calculator.Interfaces;

namespace Calculator.Operations
{
	public class Exponentiation : IOperation
	{
		public char Symbol => '^';

		public int Weight => 5;

		public decimal Execute(decimal a, decimal b) => throw new NotImplementedException();
	}
}
