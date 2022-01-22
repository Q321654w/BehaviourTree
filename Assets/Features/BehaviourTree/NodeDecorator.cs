namespace BehaviourTree
{
    public abstract class NodeDecorator : INode
    {
        protected readonly INode ChildNode;

        public NodeDecorator(INode childNode)
        {
            ChildNode = childNode;
        }

        public abstract void Enter();

        public abstract bool Execute();
    }
}