using GameEngine.Engine.Input;
using System.Windows.Input;
namespace InputEngine;

class ConsoleInput : IInput
{
    public override void StartUpdateInput()
    {
        Thread thread = new Thread(() => {
            while(true) { 
                if (Keyboard.IsKeyDown(Key.W)) KeyManager.Set(CustomKey.w);
                if (Keyboard.IsKeyDown(Key.D)) KeyManager.Set(CustomKey.d);
                if (Keyboard.IsKeyDown(Key.A)) KeyManager.Set(CustomKey.a);
                if (Keyboard.IsKeyDown(Key.S)) KeyManager.Set(CustomKey.s);
                if (Keyboard.IsKeyDown(Key.R)) KeyManager.Set(CustomKey.r);
                if (Keyboard.IsKeyDown(Key.Space)) KeyManager.Set(CustomKey.space);
                if (Keyboard.IsKeyDown(Key.Q)) KeyManager.Set(CustomKey.q);
                
                Thread.Sleep(Delay);
            }
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
    }
}
