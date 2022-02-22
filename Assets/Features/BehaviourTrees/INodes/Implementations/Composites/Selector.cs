using System.Collections.Generic;

namespace Features.BehaviourTrees.INodes.Implementations.Composites
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
            switch (currentNodeStatus)
            {
                case Status.Running:
                    _currentNode.Execute();
                    break;
                
                case Status.Success:
                case Status.Failure:
                    MoveToNextNode();
                    break;
            }
        }
        
        private void MoveToNextNode()
        {
            var canMoveNext = _enumerator.MoveNext();
            
            if (canMoveNext)
                ChangeNode();
            else
                _status = CalculateStatus();
        }

        private void ChangeNode()
        {
            _currentNode = _enumerator.Current;
            _currentNode.Enter();
        }

        private Status CalculateStatus()
        {
            foreach (var node in Nodes)
            {
                var nodeStatus = node.ExecutionStatus();
                
                if (nodeStatus == Status.Success)
                    return Status.Success;
            }

            return Status.Failure;
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