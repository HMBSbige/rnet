using BenchmarkDotNet.Running;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace rnet.Benchmark.Test;

[TestClass]
public class BenchmarkTest
{
	[TestMethod]
	public void RandFillBenchmark()
	{
		BenchmarkRunner.Run<RandFillBenchmark>();
	}

	[TestMethod]
	public void MD5Benchmark()
	{
		BenchmarkRunner.Run<MD5Benchmark>();
	}
}
