using System;

namespace BehaviourTrees
{
    public class Timer
    {
        public event Action TimIsUp;

        private readonly float _interval;

        private float _passedTime;
        private bool _isStopped = true;

        public Timer(float interval)
        {
            _interval = interval;
        }

        public void Resume()
        {
            _isStopped = false;
        }

        public void Stop()
        {
            _isStopped = true;
        }

        public void Update(float deltaTime)
        {
            if (_isStopped)
                return;

            _passedTime += deltaTime;

            if (_passedTime < _interval)
                return;

            TimIsUp?.Invoke();
            _isStopped = true;
        }

        public void Reset()
        {
            _passedTime = 0;
        }
    }
}