using System.Diagnostics;
using AoC25.Day6.TrashCompactor.Part1;

var inputFile = args[0];

await using var fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
using var sr = new StreamReader(fs);
var input = await sr.ReadToEndAsync();

var sw = new Stopwatch();
sw.Start();

var assignments = InputParser.Parse(input);
var result = assignments.Select(ass => ass.Operator.Handler(ass.Operands)).Sum();

sw.Stop();

Console.WriteLine(result);
Console.WriteLine($"Finished in {sw.ElapsedMilliseconds}ms");
