using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace Project1;

[MemoryDiagnoser]
public class ListIterationBenchmarks
{
    private readonly int _size = 10_000;
    private readonly List<string> _list = [];

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(500);
        for (int i = 1; i < _size; i++)
        {
            _list.Add(random.Next().ToString());
        }
    }

    [Benchmark]
    public void Foreach()
    {
        string x;
        foreach (string item in _list)
        {
            x = item;
        }
    }

    [Benchmark]
    public void ForEach()
    {
        string x;
        _list.ForEach((str) =>
        {
            x = str;
        });
    }

    [Benchmark]
    public void For()
    {
        string x;
        for (int i = 0; i < _list.Count; i++)
        {
            x = _list[i];
        }
    }

    [Benchmark]
    public void While()
    {
        int i = 0;
        string x;
        while (i < _list.Count)
        {
            x = _list[i];
            i++;
        }
    }

    [Benchmark]
    public void Span()
    {
        string x;
        foreach (var item in CollectionsMarshal.AsSpan(_list))
        {
            x = item;
        }
    }
}