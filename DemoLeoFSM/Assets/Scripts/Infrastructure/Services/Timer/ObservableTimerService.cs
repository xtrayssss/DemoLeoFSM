using System;
using UniRx;

namespace Infrastructure.Services.Timer
{
    public class ObservableTimerService : IObservableTimerService, IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        public IDisposable StartTimer(float time, Action onCompleted) =>
            CreateTimer(time).Subscribe(_ => onCompleted?.Invoke())
                .AddTo(_compositeDisposable);

        public IDisposable StartRepeatTimer(float time, Action onCompleted) =>
            CreateTimer(time).Repeat()
                .Subscribe(_ => onCompleted?.Invoke())
                .AddTo(_compositeDisposable);

        public void StopTimer(IDisposable disposable)
        {
            _compositeDisposable.Remove(disposable);
            disposable.Dispose();
        }

        public void Dispose()
        {
            _compositeDisposable.Clear();
            _compositeDisposable?.Dispose();
        }

        private IObservable<long> CreateTimer(float time) =>
            Observable.Timer(TimeSpan.FromSeconds(time), Scheduler.MainThreadFixedUpdate);
    }
}