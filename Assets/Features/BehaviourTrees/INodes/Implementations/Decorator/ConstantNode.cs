using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public class ConstantNode : INode
    {
        private readonly Status _status;

        public ConstantNode(bool isActive)
        {
            _status = isActive ? Status.Success : Status.Failure;
        }

        public Status ExecutionStatus()
        {
            return _status;
        }

        public void Enter()
        {
        }

        public void Execute()
        {
        }

        public void Exit()
        {
        }
    }
}