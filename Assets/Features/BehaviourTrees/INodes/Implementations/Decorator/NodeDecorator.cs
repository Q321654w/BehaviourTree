namespace Features.BehaviourTrees.INodes.Implementations.Decorator
{
    public abstract class NodeDecorator : INode
    {
        protected readonly INode ChildNode;

        public NodeDecorator(INode childNode)
        {
            ChildNode = childNode;
        }

        public abstract Status ExecutionStatus();

        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}