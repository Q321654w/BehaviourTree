namespace Features.BehaviourTrees.INodes.Implementations.Decorator
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

        public override Status ExecutionStatus()
        {
            if (_currentLoop <= _loops)
                return Status.Running;

            return ChildNode.ExecutionStatus();
        }

        public override void Enter()
        {
            ChildNode.Enter();
            Reset();
        }

        public override void Execute()
        {
            var childStatus = ChildNode.ExecutionStatus();
            if (childStatus != Status.Running && childStatus != Status.Idle)
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