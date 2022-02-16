﻿using System.Collections.Generic;
using System.Linq;
using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public abstract class NodeSequenceDecorator : INode
    {
        protected readonly INode[] Nodes;
        
        public NodeSequenceDecorator(IEnumerable<INode> nodes)
        {
            Nodes = nodes.ToArray();
        }

        public abstract bool Active();

        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}