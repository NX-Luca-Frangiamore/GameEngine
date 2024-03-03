using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public static bool ParseKey(CustomKey keyPressed)=>keys.Remove(keyPressed); 
    public static bool ParseKey(string keyPressed) {
        _ = Enum.TryParse<CustomKey>(keyPressed,true, out CustomKey key);
        return ParseKey(key);
    }
    public static bool ParseKey(string keyPressed,Action action)
    {
        _ = Enum.TryParse<CustomKey>(keyPressed, true, out CustomKey key);
        if(ParseKey(key)){
		action();
		return true;
	}
	return false;
    }
    public static bool ParseKey(CustomKey keyPressed, Action action)
    {
        if (ParseKey(keyPressed)){
		action();
		return true;
	}
	return false;
    }


}
