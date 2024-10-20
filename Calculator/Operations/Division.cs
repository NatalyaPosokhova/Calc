using Calculator.Interfaces;

namespace Calculator.Operations
{
	public class Division : IOperation
	{
		public char Symbol => '/';
		public int Weight => 3;

		public decimal Execute(decimal a, decimal b) => a / b;
	}
}
