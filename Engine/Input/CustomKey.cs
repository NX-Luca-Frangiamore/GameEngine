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
    public static bool Is(CustomKey keyPressed)=>keys.Remove(keyPressed); 
    public static bool Is(string keyPressed) {
        _ = Enum.TryParse<CustomKey>(keyPressed,true, out CustomKey key);
        return Is(key);
    }
    public static void Is(string keyPressed,Action action)
    {
        _ = Enum.TryParse<CustomKey>(keyPressed, true, out CustomKey key);
        if(Is(key))action();
    }
    public static void Is(CustomKey keyPressed, Action action)
    {
        if (Is(keyPressed)) action();
    }


}
