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