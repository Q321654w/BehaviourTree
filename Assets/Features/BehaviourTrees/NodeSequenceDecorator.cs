using System.Collections.Generic;
using System.Linq;

namespace BehaviourTrees
{
    public abstract class NodeSequenceDecorator : INode
    {
        protected readonly INode[] Nodes;
        protected readonly int NodeCollectionLength;

        public NodeSequenceDecorator(IEnumerable<INode> nodes)
        {
            Nodes = nodes.ToArray();
            NodeCollectionLength = Nodes.Length;
        }

        public abstract bool IsActive();
        
        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}