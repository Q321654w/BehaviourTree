using System.Collections.Generic;

namespace Features.BehaviourTrees.INodes.Implementations.Composites
{
    public abstract class NodeCollectionDecorator : INode
    {
        protected readonly IEnumerable<INode> Nodes;
        
        public NodeCollectionDecorator(IEnumerable<INode> nodes)
        {
            Nodes = nodes;
        }
        
        public abstract Status ExecutionStatus();

        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}