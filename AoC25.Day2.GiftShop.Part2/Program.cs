using System.Diagnostics;
using AoC25.Day2.GiftShop;
using AoC25.Day2.GiftShop.Part2;

var inputFile = args[0];

await using var fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
using var sr = new StreamReader(fs);
var input = await sr.ReadToEndAsync();

var scanner = new UnlimitedRepeatedInvalidIdScanner();
var sw = new Stopwatch();
sw.Start();

var result = new InvalidIdProcessor(scanner).Process(input);

sw.Stop();

Console.WriteLine(result); // 27180728081
Console.WriteLine($"Finished in {sw.ElapsedMilliseconds}ms");

