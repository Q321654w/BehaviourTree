using Features.BehaviourTrees;
using UnityEngine;

namespace BehaviourTrees
{
    public class TimedNode : NodeDecorator
    {
        private readonly Timer _timer;

        private Status _status;

        public TimedNode(INode childNode, Timer timer) : base(childNode)
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
        
        public override Status ExecutionStatus()
        {
            var childStatus = ChildNode.ExecutionStatus();
            if (childStatus == Status.Success && childStatus == Status.Failure)
                return childStatus;

            return _status;
        }

        public override void Enter()
        {
            ChildNode.Enter();
            _timer.Resume();
            _status = Status.Running;
        }

        public override void Execute()
        {
            _timer.Update(Time.deltaTime);
        }

        public override void Exit()
        {
            Reset();
        }

        private void Reset()
        {
            _status = Status.Idle;
            _timer.Reset();
        }
    }
}