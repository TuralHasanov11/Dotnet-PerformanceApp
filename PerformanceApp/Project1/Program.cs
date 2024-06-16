using BenchmarkDotNet.Running;
using Microsoft.Extensions.Configuration;
using Project1;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>(optional: true)
    .Build();

Console.WriteLine(configuration.GetSection("AppName").Value);

//BenchmarkRunner.Run<ListIterationBenchmarks>();
BenchmarkRunner.Run<StringConcatinationBenchmarks>();

public record Person
{
    public string Name { get; init; } = string.Empty;
    public int Age { get; init; }

    public void Deconstruct(out string name, out int age)
    {
        name = Name;
        age = Age;
    }
}
