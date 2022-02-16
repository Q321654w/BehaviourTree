using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public class OrCombiner : NodeCombiner
    {
        public OrCombiner(INode childNode, INode otherNodes) : base(childNode, otherNodes)
        {
        }

        public override bool Active()
        {
            return ChildNode.Active() | SecondNode.Active();
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