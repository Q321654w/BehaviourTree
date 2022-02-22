namespace Features.BehaviourTrees.INodes.Implementations.Decorator
{
    public class InvertedNode : NodeDecorator
    {
        public InvertedNode(INode childNode) : base(childNode)
        {
        }

        public override Status ExecutionStatus()
        {
            var childStatus = ChildNode.ExecutionStatus();

            return childStatus switch
            {
                Status.Failure => Status.Success,
                Status.Success => Status.Failure,
                _ => childStatus
            };
        }

        public override void Enter()
        {
            ChildNode.Enter();
        }

        public override void Execute()
        {
            ChildNode.Execute();
        }

        public override void Exit()
        {
            ChildNode.Exit();
        }
    }
}