namespace Calculator.Checkers
{
	public abstract class Checker
	{
		private Checker _next;

		public Checker(Checker Next)
		{
			_next = Next;
		}

		public virtual bool ValidateString(string exp)
		{
			return _next != null ? _next.ValidateString(exp) : true;
		}
	}
}
