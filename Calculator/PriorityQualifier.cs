using Calculator.Interfaces;

namespace Calculator
{
	public class PriorityQualifier : IPriorityQualifier
	{
		private readonly IOrderedEnumerable<IGrouping<int, IOperation>> _highToLowOperations;
		public PriorityQualifier()
        {
			var types = AppDomain.CurrentDomain.GetAssemblies()
			.SelectMany(s => s.GetTypes())
			.Where(p => typeof(IOperation).IsAssignableFrom(p) && !p.IsInterface);

			var operations = new List<IOperation>();
			foreach (var type in types)
			{
				var obj = (IOperation)Activator.CreateInstance(type);
				operations.Add(obj);
			}
			_highToLowOperations = operations
				.GroupBy(op => op.Weight)
				.OrderByDescending(op => op.Key);
		}
        public int GetFirstHighPriorityOperationIndex(string exp)
		{
			var index = -1;
			foreach (var op in _highToLowOperations)
			{
				index = exp.IndexOfAny(op.Select(i => i.Symbol).ToArray(), 1);
				if (index != -1)
					return index;
			}
			return index;
		}
	}
}
