﻿using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public class AndCombiner : NodeCombiner
    {
        public AndCombiner(INode childNode, INode secondNode) : base(childNode, secondNode)
        {
        }

        public override bool Active()
        {
            return ChildNode.Active() & SecondNode.Active();
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