using System.Collections.Generic;
using System.Linq;

namespace BehaviourTree
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

        public void Enter()
        {
            foreach (var node in Nodes)
            {
                node.Enter();
            }

            InternalEnter();
        }

        protected abstract void InternalEnter();

        public abstract bool Execute();
    }
}