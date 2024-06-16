using BenchmarkDotNet.Attributes;
using System.Text;

namespace Project1;

[MemoryDiagnoser]
public class StringConcatinationBenchmarks
{
    private const string word1 = "abcsosdsndnsdsnwiejijesafdsfkdsfkfsdfjffdsfqwoewqoe";
    private const string word2 = "pqrwetpoprtpoertkergmgfdfmgfkgfkgljfdgjdfggjfsdfjds";

    [Benchmark]
    public string SpanIteration()
    {
        StringBuilder stringBuilder = new();
        ReadOnlySpan<char> charSpan1 = word1.AsSpan();
        ReadOnlySpan<char> charSpan2 = word2.AsSpan();

        int i = 0;

        while (i < charSpan1.Length && i < charSpan2.Length)
        {
            stringBuilder.Append(charSpan1[i]);
            stringBuilder.Append(charSpan2[i]);
            i++;
        }

        while (i < charSpan1.Length)
        {
            stringBuilder.Append(charSpan1[i]);
            i++;
        }

        while (i < charSpan2.Length)
        {
            stringBuilder.Append(charSpan2[i]);
            i++;
        }

        return stringBuilder.ToString();
    }

    [Benchmark]
    public string NormalIteration()
    {
        StringBuilder stringBuilder = new();

        int i = 0;

        while (i < word1.Length && i < word2.Length)
        {
            stringBuilder.Append(word1[i]);
            stringBuilder.Append(word2[i]);
            i++;
        }

        while (i < word1.Length)
        {
            stringBuilder.Append(word1[i]);
            i++;
        }

        while (i < word2.Length)
        {
            stringBuilder.Append(word2[i]);
            i++;
        }

        return stringBuilder.ToString();
    }

}