using Calculator.Interfaces;

namespace Calculator
{
	public class Calculator
	{
		private readonly IParser _parser;
        public Calculator()
        {
			_parser = new Parser();
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
