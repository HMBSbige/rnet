namespace rnet;

internal static class NativeMethods
{
	private const string DllName = @"rnet_native";

	[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
	[SuppressGCTransition]
	public static extern nint rand_fill(nuint ptr, nuint size);

	[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
	[SuppressGCTransition]
	public static extern nuint md5_new();

	[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
	[SuppressGCTransition]
	public static extern void md5_dispose(nuint ptr);

	[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
	[SuppressGCTransition]
	public static extern void md5_reset(nuint ptr);

	[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
	[SuppressGCTransition]
	public static extern void md5_update_final(nuint ptr, nuint input, nuint inputSize, nuint output, nuint outputSize);

	[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
	[SuppressGCTransition]
	public static extern void md5_update(nuint ptr, nuint input, nuint inputSize);

	[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
	[SuppressGCTransition]
	public static extern void md5_get_hash(nuint ptr, nuint output, nuint outputSize);
}
