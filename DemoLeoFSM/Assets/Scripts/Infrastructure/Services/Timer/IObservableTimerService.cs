using System;

namespace Infrastructure.Services.Timer
{
    public interface IObservableTimerService
    {
        public IDisposable StartTimer(float time, Action onCompleted);
        public void StopTimer(IDisposable timer);
        IDisposable StartRepeatTimer(float time, Action onCompleted);
    }
}