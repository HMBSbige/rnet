using BenchmarkDotNet.Attributes;
using CryptoBase.Digests.MD5;
using System.Security.Cryptography;

namespace rnet.Benchmark;

[MemoryDiagnoser]
public class MD5Benchmark
{
	[Params(16 + 6, 16 + 16, 114514)]
	public int ByteLength { get; set; }

	private Memory<byte> _randombytes;

	[GlobalSetup]
	public void Setup()
	{
		_randombytes = RandomNumberGenerator.GetBytes(ByteLength);
	}

	[Benchmark(Baseline = true)]
	public void Default()
	{
		using DefaultMD5Digest md5 = new();
		md5.Update(_randombytes.Span);
	}

	[Benchmark]
	public void Native()
	{
		using Md5Native md5 = new();
		md5.Update(_randombytes.Span);
	}
}
