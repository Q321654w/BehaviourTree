namespace Features.BehaviourTrees.INodes.Implementations.Decorator
{
    public class WaitUntilFailure : NodeDecorator
    {
        private Status _status;

        public WaitUntilFailure(INode childNode) : base(childNode)
        {
            _status = Status.Idle;
        }

        public override Status ExecutionStatus()
        {
            return _status;
        }

        public override void Enter()
        {
            _status = Status.Running;
            ChildNode.Enter();
        }

        public override void Execute()
        {
            var childStatus = ChildNode.ExecutionStatus();

            if (childStatus == Status.Failure)
                _status = childStatus;

            ChildNode.Execute();
        }

        public override void Exit()
        {
            _status = Status.Idle;
            ChildNode.Exit();
        }
    }
}