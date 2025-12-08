using AoC25.Day1.SecretEntrance.Part1;

var inputFile = args[0];

await using var fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
using var sr = new StreamReader(fs);
var input = await sr.ReadToEndAsync();
var result = new SafeProcessor().Process(input);

Console.WriteLine(result); // 1172