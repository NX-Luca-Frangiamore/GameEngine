using System.Security.Cryptography;

namespace Utils;
public abstract class IInput{
    public string? state=null;
    public abstract void StartUpdateInput(); 

    private int _delay=500;
    public int Delay{ get{ return _delay; } set{ if (value > 0) _delay = value; }}
}
class ConsoleInput : IInput
{
    public override void StartUpdateInput()
    {
        Task.Run(() => {
            while (true)
            {
                state = Console.ReadKey(true).KeyChar switch
                {
                    'a' => "left",
                    'w' => "up",
                    'd' => "right",
                    's' => "down",
                    _ => state
                };
                Thread.Sleep(Delay);
            }
        });
    }
}