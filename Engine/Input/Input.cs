namespace InputEngine;
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