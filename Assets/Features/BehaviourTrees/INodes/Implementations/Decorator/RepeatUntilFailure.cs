namespace Features.BehaviourTrees.INodes.Implementations.Decorator
{
    public class RepeatUntilFailure : NodeDecorator
    {
        public RepeatUntilFailure(INode childNode) : base(childNode)
        {
        }

        public override Status ExecutionStatus()
        {
            if (ChildNode.ExecutionStatus() != Status.Failure)
                return Status.Running;

            return ChildNode.ExecutionStatus();
        }

        public override void Enter()
        {
            ChildNode.Enter();
            
        }

        public override void Execute()
        {
            var childStatus = ChildNode.ExecutionStatus();
            if (childStatus != Status.Running && childStatus != Status.Idle)
            {
               
                ChildNode.Exit();
                ChildNode.Enter();
            }

            ChildNode.Execute();
        }

        public override void Exit()
        {
            ChildNode.Exit();
        }
    }
}