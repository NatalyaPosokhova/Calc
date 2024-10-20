using Calculator.Interfaces;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator.Checkers
{
	internal class AllowedSymbolsChecker : Checker
	{
		public AllowedSymbolsChecker(Checker Next) : base(Next) { }
		public override bool ValidateString(string exp)
		{
			var sb = new StringBuilder(Constants.AllowedSymbols);

			var types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => typeof(IOperation).IsAssignableFrom(p) && !p.IsInterface);

			foreach (var type in types)
			{
				var obj = (IOperation)Activator.CreateInstance(type);
				sb.Append('|');
				sb.Append('\\');
				sb.Append(obj.Symbol);
			}

			if (!exp.All(ch => Regex.IsMatch(ch.ToString(), sb.ToString())))
				return false;

			return base.ValidateString(exp);
		}
	}
}
