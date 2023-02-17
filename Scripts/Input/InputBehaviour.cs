public abstract class InputBehaviour
{
    public GameInput input;
    public abstract void Start();
    public abstract void Stop();
    public virtual void Move() { }

}
