public class TraslatedObjectCommand : ICommand
{
    public TraslatedObjectCommand(Object.Object o) : base(o)
    {
    }

    public override void Execute()
    {
        throw new NotImplementedException();
    }
}