// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using Calculator;
using Calculator.Interfaces;

Console.Write("Введите выражение:");
var exp = Console.ReadLine();

if(!Calculator.Validator.ValidateExpression(exp))
{
	Console.WriteLine("Некорректное выражение");
	return;
}
exp = exp.Replace(" ", "");

var parser = new Parser();
var priorityQualifier = new PriorityQualifier();
var calculator = new Calculator.Calculator(parser, priorityQualifier);
var res = calculator.CalculateExpression(exp);

Console.WriteLine($"Результат: {res}");
