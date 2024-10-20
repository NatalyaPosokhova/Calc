using Calculator.Interfaces;

namespace Calculator.Operations
{
	public class Exponentiation : IOperation
	{
		public char Symbol => '^';

		public int Weight => 5;

		public decimal Execute(decimal a, decimal b)
		{
			decimal result = 1;
			for (int i = 0; i < b; i++)
			{
				result *= a;
			}
			return result;
		}
	}
}
