﻿namespace BehaviourTrees
{
    public class InvertedNode : NodeDecorator
    {
        public InvertedNode(INode childNode) : base(childNode)
        {
        }

        public override bool IsActive()
        {
            return !ChildNode.IsActive();
        }

        public override void Enter()
        {
            ChildNode.Enter();
        }

        public override void Execute()
        {
            ChildNode.Execute();
        }
        
        public override void Exit()
        {
            ChildNode.Exit();
        }
    }
}