using AoC25.Features._1_SecretEntrance.Part2;

var inputFile = args[0];

await using var fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
using var sr = new StreamReader(fs);
var input = await sr.ReadToEndAsync();
var result = new SafeProcessor().Process(input); 

Console.WriteLine(result); // 6932