using System.Diagnostics;
using AoC25.Day5.Cafeteria.Part2;

var inputFile = args[0];

await using var fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
using var sr = new StreamReader(fs);
var input = await sr.ReadToEndAsync();

var sw = new Stopwatch();
sw.Start();

var db = InputParser.Parse(input);
FreshRangeService.OptimizeFreshRange(db);
var result = FreshRangeService.GetFreshRangeCount(db);
sw.Stop();

Console.WriteLine(result);
Console.WriteLine($"Finished in {sw.ElapsedMilliseconds}ms");