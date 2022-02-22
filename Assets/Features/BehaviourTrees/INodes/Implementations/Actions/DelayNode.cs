using Features.BehaviourTrees.Common;
using UnityEngine;

namespace Features.BehaviourTrees.INodes.Implementations.Actions
{
    public class DelayNode : INode
    {
        private readonly Timer _timer;
        private Status _status;

        public DelayNode(Timer timer)
        {
            _status = Status.Idle;
            _timer = timer;
            _timer.TimIsUp += OnTimeIsUp;
        }

        private void OnTimeIsUp()
        {
            _status = Status.Success;
            _timer.Stop();
        }

        public Status ExecutionStatus()
        {
            return _status;
        }

        public void Enter()
        {
            _status = Status.Running;
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
            _status = Status.Idle;
        }
    }
}