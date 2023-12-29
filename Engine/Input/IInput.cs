namespace InputEngine;
public abstract class IInput{
    public string? state=null;
    public abstract void StartUpdateInput(); 

    private int _delay=500;
    public int Delay{ get{ return _delay; } set{ if (value > 0) _delay = value; }}
}