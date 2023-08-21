using System;
using UnityEngine;

namespace Infrastructure.Services.Timer
{
    public class ControllableTimer : IControllableTimer
    {
        private float _time;
        private readonly Action _onCompleted;
        public bool IsDone { get; private set; }
        public float CurrentTime { get; private set; }

        public ControllableTimer(float time, Action onCompleted)
        {
            _time = time;
            _onCompleted = onCompleted;
        }

        public ControllableTimer()
        {
        }

        public ControllableTimer(float time) =>
            _time = time;

        public void Tick()
        {
            _time -= Time.deltaTime;
            CurrentTime += Time.deltaTime;

            if (!(_time <= 0.0f))
                return;

            IsDone = true;
            _onCompleted?.Invoke();
        }

        public void SetTime(float newTime)
        {
            _time = newTime;
            IsDone = false;
            CurrentTime = 0;
        }
    }
}