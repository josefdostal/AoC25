using System.Diagnostics;
using AoC25.Day3.Lobby;
using AoC25.Day3.Lobby.Part2;

var inputFile = args[0];

await using var fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
using var sr = new StreamReader(fs);
var input = await sr.ReadToEndAsync();

var banks = InputParser.GetBatteryBanks(input);

var sw = new Stopwatch();
sw.Start();

var result = banks.Sum(JoltageOptimizer.GetHighestJoltage);

sw.Stop();

Console.WriteLine(result); // 172787336861064
Console.WriteLine($"Finished in {sw.ElapsedMilliseconds}ms");