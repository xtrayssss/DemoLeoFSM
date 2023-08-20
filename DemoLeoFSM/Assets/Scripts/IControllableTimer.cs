public interface IControllableTimer
{
    public void Tick();
    public void SetTime(float newTime);
    float CurrentTime { get; }
}