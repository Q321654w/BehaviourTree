using Features.BehaviourTrees;
using UnityEngine;

namespace BehaviourTrees
{
    public class TimedNode : NodeDecorator
    {
        private readonly Timer _timer;

        private bool _isActive;

        public TimedNode(INode childNode, Timer timer) : base(childNode)
        {
            _isActive = true;
            _timer = timer;
            _timer.TimIsUp += OnTimeIsUp;
        }

        private void OnTimeIsUp()
        {
            _isActive = false;
            _timer.Stop();
        }

        public override bool Active()
        {
            return _isActive;
        }

        public override void Enter()
        {
            ChildNode.Enter();
            _timer.Resume();
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
            _isActive = true;
            _timer.Reset();
        }
    }
}