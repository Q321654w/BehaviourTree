using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public abstract class NodeCombiner : NodeDecorator
    {
        protected INode SecondNode;

        public NodeCombiner(INode childNode, INode secondNode) : base(childNode)
        {
            SecondNode = secondNode;
        }

        public override void Enter()
        {
            ChildNode.Enter();
            SecondNode.Enter();
        }

        public abstract override void Execute();
    }
}