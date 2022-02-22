using System.Collections.Generic;

namespace Features.BehaviourTrees.INodes.Implementations.Composites
{
    public class Parallel : NodeCollectionDecorator
    {
        private Status _status;

        public Parallel(IEnumerable<INode> nodes) : base(nodes)
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
            var status = Status.Success;
            var isAllComplete = true;

            while (enumerator.MoveNext())
            {
                var currentNode = enumerator.Current;
                var currentNodeStatus = currentNode.ExecutionStatus();

                switch (currentNodeStatus)
                {
                    case Status.Running:
                        isAllComplete = false;
                        break;

                    case Status.Failure:
                        status = Status.Failure;
                        break;
                }
            }

            if (isAllComplete)
                _status = status;
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