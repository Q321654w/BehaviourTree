using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public class WaitWhile : NodeDecorator
    {
        private Status _status;

        public WaitWhile(INode childNode) : base(childNode)
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
            ChildNode.Enter();
        }

        public override void Execute()
        {
            var childStatus = ChildNode.ExecutionStatus();
            ChildNode.Execute();
            
            if (childStatus != Status.Idle && childStatus != Status.Running)
                _status = childStatus;
        }

        public override void Exit()
        {
            _status = Status.Idle;
            ChildNode.Exit();
        }
    }
}