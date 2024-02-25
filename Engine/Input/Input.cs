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
                    ConsoleKey.R => "r",
                    ConsoleKey.Spacebar => "space",
                    ConsoleKey.Q => "q",
                    _ => ""
                };
                while (Console.KeyAvailable)Console.ReadKey(true);
                
                Thread.Sleep(Delay);
            }
        });
    }
}