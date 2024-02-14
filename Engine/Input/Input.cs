namespace InputEngine;
class ConsoleInput : IInput
{
    public override void StartUpdateInput()
    {
        Task.Run(() => {
            while (true)
            {
                keyPressed = Console.ReadKey(true).Key switch
                {
                    ConsoleKey.A => "a",
                    ConsoleKey.W => "w",
                    ConsoleKey.D => "d",
                    ConsoleKey.S => "s",
                    ConsoleKey.Spacebar => "space",
                    _ => ""
                };
                while (Console.KeyAvailable)Console.ReadKey(true);
                
                Thread.Sleep(Delay);
            }
        });
    }
}