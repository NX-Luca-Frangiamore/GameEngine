namespace InputEngine;
public abstract class IInput{
    private string? _keyPressed = null;

    public string? keyPressed
    {
        get { var t=_keyPressed;_keyPressed = null; return t; }
        set { _keyPressed = value; }

    }

    public abstract void StartUpdateInput(); 
    public void Reset()=>keyPressed=null;

    private int _delay=500;
    public int Delay{ get{ return _delay; } set{ if (value > 0) _delay = value; }}
}