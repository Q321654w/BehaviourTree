using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public class LoopNode : NodeDecorator
    {
        private readonly int _loops;
        private int _currentLoop;

        public LoopNode(INode childNode, int loops) : base(childNode)
        {
            _loops = loops;
            _currentLoop = 0;
        }

        public override bool Active()
        {
            return _currentLoop >= _loops;
        }

        public override void Enter()
        {
            ChildNode.Enter();
            Reset();
        }

        public override void Execute()
        {
            if (!ChildNode.Active())
            {
                _currentLoop++;
                ChildNode.Exit();
                ChildNode.Enter();
            }

            ChildNode.Execute();
        }

        public override void Exit()
        {
            ChildNode.Exit();
            Reset();
        }

        private void Reset()
        {
            _currentLoop = 0;
        }
    }
}