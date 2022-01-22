using UnityEngine;

namespace BehaviourTree
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

        public override void Enter()
        {
            ChildNode.Enter();
            
            Reset();
            _timer.Resume();
        }

        public override bool Execute()
        {
            _timer.Update(Time.deltaTime);
            return _isActive;
        }

        private void Reset()
        {
            _isActive = true;
            _timer.Reset();
        }
    }
}