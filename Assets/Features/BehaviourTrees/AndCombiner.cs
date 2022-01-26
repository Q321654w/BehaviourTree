﻿ namespace BehaviourTrees
{
    public class AndCombiner : NodeCombiner
    {
        public AndCombiner(INode childNode, INode secondNode) : base(childNode, secondNode)
        {
        }

        public override bool IsActive()
        {
            return ChildNode.IsActive() & SecondNode.IsActive();
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