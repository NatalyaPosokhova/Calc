using Calculator.Interfaces;

namespace Calculator.Operations
{
	public class Division : IOperation
	{
		public char Symbol => '/';

		public decimal Execute(decimal a, decimal b)
		{
			throw new NotImplementedException();
		}
	}
}
