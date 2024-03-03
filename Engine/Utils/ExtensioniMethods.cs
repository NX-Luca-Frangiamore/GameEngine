public static class ExtensionBool{
	public static bool Or(this bool first,Func<bool> than)=>than();
}
