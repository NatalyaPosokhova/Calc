using Calculator.Interfaces;

namespace Calculator
{
	public class Calculator
	{
		private readonly IParser _parser;
		private readonly IOperationsPerformer _operationsPerformer;
		private readonly IPriorityQualifier _priorityQualifier;
		public Calculator(IParser parser, IOperationsPerformer operationsPerformer, IPriorityQualifier priorityQualifier)
		{
			_parser = parser;
			_operationsPerformer = operationsPerformer;
			_priorityQualifier = priorityQualifier;
		}
		public decimal CalculateExpression(string exp)
		{
			throw new NotImplementedException();
		}

		public decimal CalculateExpressionWithoutBraces(string exp)
		{
			throw new NotImplementedException();
		}
	}
}
