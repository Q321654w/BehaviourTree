namespace BehaviourTrees
{
    public class OrCombiner : NodeCombiner
    {
        public OrCombiner(INode childNode, INode otherNodes) : base(childNode, otherNodes)
        {
        }

        public override bool IsActive()
        {
            return ChildNode.IsActive() | SecondNode.IsActive();
        }

        public override void Execute()
        {
            ChildNode.Execute();
            SecondNode.Execute();
        }

        public override void Exit()
        {
            ChildNode.Exit();
            SecondNode.Exit();
        }
    }
}