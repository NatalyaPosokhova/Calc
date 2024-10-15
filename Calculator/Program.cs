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
exp = exp.Trim();

var parser = new Parser();
var operationsPerformer = new OperationsPerformer();
var priorityQualifier = new PriorityQualifier();
var calculator = new Calculator.Calculator(parser, operationsPerformer, priorityQualifier);
var res = calculator.CalculateExpression(exp);
Console.WriteLine($"Результат: {res}");
