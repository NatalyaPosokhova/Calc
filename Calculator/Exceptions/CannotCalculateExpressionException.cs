namespace Calculator.Exceptions
{
	public class CannotCalculateExpressionException : Exception
	{
		public CannotCalculateExpressionException(string Message, Exception ex) : base(Message, ex)
		{

		}
	}
}
