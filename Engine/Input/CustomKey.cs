namespace GameEngine.Engine.Input;
public enum CustomKey
{
    a, b, c, d, r,w,s,space ,shift,
    q
}
public class KeyManager
{
    public static Dictionary<CustomKey,bool> keys = [];
    public static void Set(CustomKey key) =>keys[key]=true;
    public static bool IsThere(CustomKey keyPressed)=>keys.Remove(keyPressed); 
    public static bool IsThere(string keyPressed) {
        _ = Enum.TryParse<CustomKey>(keyPressed,true, out CustomKey key);
        return IsThere(key);
    }
    public static bool IsThereThen(string keyPressed,Action action)
    {
        _ = Enum.TryParse<CustomKey>(keyPressed, true, out CustomKey key);
        if(IsThere(key)){
		action();
		return true;
	}
	return false;
    }
}
