namespace Calculator.Interfaces
{
	public interface IOperation
	{
		public char Symbol { get;}
		public int Weight { get; }
		public decimal Execute(decimal a, decimal b);
	}
}
