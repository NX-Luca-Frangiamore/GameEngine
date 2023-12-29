public  abstract class ICommand{
    private Object.Object @object;
    public abstract void Execute();
    public ICommand(Object.Object o){
        @object = o;
    }
}