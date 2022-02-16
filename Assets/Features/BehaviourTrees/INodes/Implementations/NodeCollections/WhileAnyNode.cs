﻿using System.Collections.Generic;
using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public class WhileAnyNode : NodeSequenceDecorator
    {
        public WhileAnyNode(IEnumerable<INode> nodes) : base(nodes)
        {
        }

        public override void Enter()
        {
            foreach (var node in Nodes)
            {
                node.Enter();
            }
        }

        public override bool Active()
        {
            foreach (var node in Nodes)
            {
                if (!node.Active())
                    continue;

                return true;
            }

            return false;
        }

        public override void Execute()
        {
            foreach (var node in Nodes)
            {
                node.Execute();
            }
        }

        public override void Exit()
        {
            foreach (var node in Nodes)
            {
                node.Exit();
            }
        }
    }
}