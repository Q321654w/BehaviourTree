using System.Collections.Generic;
using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public class Sequence : NodeCollectionDecorator
    {
        private IEnumerator<INode> _enumerator;
        private Status _status;
        private INode _currentNode;

        public Sequence(IEnumerable<INode> nodes) : base(nodes)
        {
            _status = Status.Idle;
        }

        public override Status ExecutionStatus()
        {
            return _status;
        }

        public override void Enter()
        {
            _status = Status.Running;
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
                    MoveToNextNode();
                    break;
                
                case Status.Failure:
                    _status = Status.Failure;
                    break;
            }
        }

        private void MoveToNextNode()
        {
            if (!_enumerator.MoveNext())
            {
                _status = Status.Success;
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