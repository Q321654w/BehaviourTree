using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public abstract class NodeDecorator : INode
    {
        protected readonly INode ChildNode;

        public NodeDecorator(INode childNode)
        {
            ChildNode = childNode;
        }

        public abstract bool Active();
        
        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}