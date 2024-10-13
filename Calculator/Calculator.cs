using Calculator.Interfaces;

namespace Calculator
{
	public class Calculator
	{
		private readonly IParser _parser;
		private readonly IOperationsPerformer _operationsPerformer;
		private readonly IPriorityQualifier _priorityQualifier;
		public Calculator()
		{
			_parser = new Parser();
			_operationsPerformer = new OperationsPerformer();
			_priorityQualifier = new PriorityQualifier();
		}
		public decimal CalculateExpression(string exp)
		{
			throw new NotImplementedException();
		}

		private decimal CalculateExpressionWithoutBraces(string exp)
		{
			throw new NotImplementedException();
		}
	}
}
