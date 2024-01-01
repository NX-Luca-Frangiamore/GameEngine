namespace InputEngine;
class ConsoleInput : IInput
{
    public override void StartUpdateInput()
    {
        Task.Run(() => {
            while (true)
            {
                keyPressed = Console.ReadKey(true).KeyChar switch
                {
                    'a' => "left",
                    'w' => "up",
                    'd' => "right",
                    's' => "down",
                    _ => keyPressed
                };
                Thread.Sleep(Delay);
            }
        });
    }
}