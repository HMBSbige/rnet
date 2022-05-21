using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;

namespace rnet.Benchmark;

[MemoryDiagnoser]
public class RandFillBenchmark
{
	[Params(16, 1024, 1024 * 1024)]
	public int Length { get; set; }

	private byte[] _buffer = Array.Empty<byte>();

	[GlobalSetup]
	public void Setup()
	{
		_buffer = new byte[Length];
	}

	[Benchmark(Baseline = true)]
	public void Dotnet()
	{
		RandomNumberGenerator.Fill(_buffer);
	}

	[Benchmark]
	public void Rust()
	{
		Rand.Fill(_buffer);
	}
}
