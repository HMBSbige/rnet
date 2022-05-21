namespace rnet;

internal static class NativeMethods
{
	private const string DllName = @"rnet_native";

	[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
	[SuppressGCTransition]
	public static extern nint rand_fill(nuint ptr, nuint size);
}
