namespace rnet;

public static class Rand
{
	public static unsafe void Fill(Span<byte> data)
	{
		if (data.Length <= 0)
		{
			return;
		}

		fixed (byte* ptr = data)
		{
			nint status = NativeMethods.rand_fill((nuint)ptr, (nuint)data.Length);
			if (status is not 0)
			{
				throw new CryptographicException(@"Fill with random data failed.");
			}
		}
	}
}
