namespace BehaviourTree
{
    public class InvertedNode : NodeDecorator
    {
        public InvertedNode(INode childNode) : base(childNode)
        {
        }

        public override void Enter()
        {
            ChildNode.Enter();
        }

        public override bool Execute()
        {
            return !ChildNode.Execute();
        }
    }
}