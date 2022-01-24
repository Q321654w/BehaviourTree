using UnityEngine;

namespace BehaviourTree
{
    public class DelayedNode : NodeDecorator
    {
        private readonly Timer _timer;

        private bool _thisNodeIsActive;

        public DelayedNode(INode childNode, Timer timer) : base(childNode)
        {
            _timer = timer;
            _thisNodeIsActive = true;
            _timer.TimIsUp += OnTimeIsUp;
        }

        private void OnTimeIsUp()
        {
            _thisNodeIsActive = false;
            _timer.Stop();
        }

        public override void Enter()
        {
            ChildNode.Enter();
            _timer.Resume();
        }

        private void Reset()
        {
            _timer.Reset();
            _thisNodeIsActive = true;
        }

        public override bool Execute()
        {
            if (_thisNodeIsActive)
            {
                _timer.Update(Time.deltaTime);
                return true;
            }

            var childNodeIsActive = ChildNode.Execute();

            if (!childNodeIsActive)
                Reset();
            
            return childNodeIsActive;
        }
    }
}