using System.Collections.Generic;
using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public class Selector : NodeCollectionDecorator
    {
        private IEnumerator<INode> _enumerator;
        private Status _status;
        private INode _currentNode;

        public Selector(IEnumerable<INode> nodes) : base(nodes)
        {
            _status = Status.Idle;
        }

        public override Status ExecutionStatus()
        {
            return _status;
        }

        public override void Enter()
        {
            _enumerator = Nodes.GetEnumerator();
            MoveToNextNode();
        }
        
        public override void Execute()
        {
            var currentNodeStatus = _currentNode.ExecutionStatus();
            if (currentNodeStatus == Status.Running)
            {
                _currentNode.Execute();
                return;
            }

            if (currentNodeStatus == Status.Success || currentNodeStatus == Status.Failure)
                MoveToNextNode();
        }
        
        private void MoveToNextNode()
        {
            if (!_enumerator.MoveNext())
            {
                bool isAllFailure = true;

                foreach (var node in Nodes)
                {
                    var nodeStatus = node.ExecutionStatus();
                    isAllFailure = isAllFailure && nodeStatus == Status.Failure;
                }

                _status = isAllFailure ? Status.Failure : Status.Success;
                return;
            }

            _currentNode = _enumerator.Current;
            _currentNode.Enter();
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