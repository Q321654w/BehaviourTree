﻿using System.Collections.Generic;

namespace Features.BehaviourTrees.INodes.Implementations.Composites
{
    public class ParallelComplete : NodeCollectionDecorator
    {
        private Status _status;

        public ParallelComplete(IEnumerable<INode> nodes) : base(nodes)
        {
        }

        public override Status ExecutionStatus()
        {
            return _status;
        }

        public override void Enter()
        {
            _status = Status.Running;

            foreach (var node in Nodes)
                node.Enter();
        }

        public override void Execute()
        {
            var enumerator = Nodes.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var currentNode = enumerator.Current;
                var currentNodeStatus = currentNode.ExecutionStatus();

                if (currentNodeStatus != Status.Success && currentNodeStatus != Status.Failure) 
                    continue;
                
                _status = currentNodeStatus;
                break;
            }
        }

        public override void Exit()
        {
            foreach (var node in Nodes)
            {
                node.Exit();
            }

            _status = Status.Idle;
        }
    }
}