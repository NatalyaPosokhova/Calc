namespace Calculator.Interfaces
{
	public interface IOperationsPerformer
	{
		public decimal Add(decimal a, decimal b);
		public decimal Substract(decimal a, decimal b);
		public decimal Multiply(decimal a, decimal b);
		public decimal Divide(decimal a, decimal b);
	}
}
