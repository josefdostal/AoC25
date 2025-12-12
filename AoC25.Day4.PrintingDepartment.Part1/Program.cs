using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using AoC25.Day4.PrintingDepartment;

var inputFile = args[0];

await using var fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
using var sr = new StreamReader(fs);
var input = await sr.ReadToEndAsync();

var inputParser = new InputParser();
var locator = new ReachableRollLocator(4);

var sw = new Stopwatch();
sw.Start();

var shelf = inputParser.Parse(input);
locator.GetReachableRollCount(shelf);

sw.Stop();

Console.WriteLine(locator.Count); // 1424
Console.WriteLine($"Finished in {sw.ElapsedMilliseconds}ms");