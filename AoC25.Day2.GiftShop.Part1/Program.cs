// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using AoC25.Day2.GiftShop;
using AoC25.Day2.GiftShop.Part1;

var inputFile = args[0];

await using var fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
using var sr = new StreamReader(fs);
var input = await sr.ReadToEndAsync();

var scanner = new HalfsRepeatedInvalidIdScanner();

var sw = new Stopwatch();
sw.Start();

var result = new InvalidIdProcessor(scanner).Process(input);

sw.Stop();

Console.WriteLine(result); // 19219508902
Console.WriteLine($"Finished in {sw.ElapsedMilliseconds}ms");
