using Calculator.Interfaces;

namespace Calculator.Operations
{
	public class Addition : IOperation
	{
		public char Symbol => '+';

		public int Weight => 1;

		public decimal Execute(decimal a, decimal b) => a + b;
	}
}
