using Graphics.Display;
using GameEngine.Object;

namespace Graphics.GraphicsEngine;
public abstract class IGraphicsEngine{
    public IDisplay Display;
    public abstract void ShowFrame(List<DtoGraphicsEngine> sprites);
    public abstract void ShowEmptyFrame();

    public IGraphicsEngine(IDisplay display){
        this.Display = display;
    } 
}