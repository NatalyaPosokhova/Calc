namespace Calculator.Interfaces
{
	public interface IOperation
	{
		public char Symbol { get;}
		public decimal Execute(decimal a, decimal b);
	}
}
