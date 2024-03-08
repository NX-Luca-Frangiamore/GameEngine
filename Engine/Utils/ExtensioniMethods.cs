public static class ExtensionBool{
	public static bool Or(this bool _,Func<bool> than)=>than();
}
