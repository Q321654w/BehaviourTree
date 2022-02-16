using Features.BehaviourTrees;
using UnityEngine;

namespace BehaviourTrees
{
    public class DelayNode : INode
    {
        private readonly Timer _timer;

        private bool _isActive;

        public DelayNode(Timer timer)
        {
            _timer = timer;
            _isActive = true;
            _timer.TimIsUp += OnTimeIsUp;
        }

        private void OnTimeIsUp()
        {
            _isActive = false;
            _timer.Stop();
        }

        public bool Active()
        {
            return _isActive;
        }

        public void Enter()
        {
            _timer.Resume();
        }

        public void Execute()
        {
            _timer.Update(Time.deltaTime);
        }

        public void Exit()
        {
            Reset();
        }

        private void Reset()
        {
            _timer.Reset();
            _isActive = true;
        }
    }
}