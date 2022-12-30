using BenchmarkDotNet.Running;
using MeasurePerformances;

BenchmarkAPIs benchmarks = new BenchmarkAPIs();
benchmarks.RetrieveAlbums();

var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

Console.WriteLine("Hello, World!");
