namespace BehaviourTree
{
    public class AndCombiner : NodeCombiner
    {
        public AndCombiner(INode childNode, INode secondNode) : base(childNode, secondNode)
        {
        }

        public override bool Execute()
        {
            return ChildNode.Execute() & SecondNode.Execute();
        }
    }
}