using System.Diagnostics;
using AoC25.Day4.PrintingDepartment;
using AoC25.Day4.PrintingDepartment.Part2;

var inputFile = args[0];

await using var fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
using var sr = new StreamReader(fs);
var input = await sr.ReadToEndAsync();

var inputParser = new InputParser();

var sw = new Stopwatch();
sw.Start();

var shelf = inputParser.Parse(input);
var result = Planner.Plan(shelf);

sw.Stop();

Console.WriteLine(result); // 8727
Console.WriteLine($"Finished in {sw.ElapsedMilliseconds}ms");
