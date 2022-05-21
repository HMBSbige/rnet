namespace rnet.Tests;

[TestClass]
public class RandTest
{
	[TestMethod]
	public void TestFill()
	{
		int size = RandomNumberGenerator.GetInt32(1, 1024);
		Span<byte> empty = new byte[size];
		Span<byte> data = new byte[size];
		Assert.IsTrue(data.SequenceEqual(empty));
		Rand.Fill(data);
		Assert.IsFalse(data.SequenceEqual(empty));
	}
}
