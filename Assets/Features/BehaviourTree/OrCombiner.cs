namespace BehaviourTree
{
    public class OrCombiner : NodeCombiner
    {
        public OrCombiner(INode childNode, INode otherNodes) : base(childNode, otherNodes)
        {
        }

        public override bool Execute()
        {
            return ChildNode.Execute() | SecondNode.Execute();
        }
    }
}