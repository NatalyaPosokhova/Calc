using Calculator.Interfaces;

namespace Calculator
{
	public class PriorityQualifier : IPriorityQualifier
	{
		public int GetFirstHighPriorityOperationIndex(string exp)
		{
			var index = exp.IndexOfAny(['*', '/']);

			if(index == -1)
				index = exp.IndexOfAny(['+', '-'], 1);

			return index;
		}
	}
}
