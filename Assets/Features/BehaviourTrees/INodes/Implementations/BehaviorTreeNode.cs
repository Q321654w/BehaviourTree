using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public class BehaviorTreeNode : INode
    {
        private readonly BehaviourTree _behaviourTree;
        private Status _status;

        public BehaviorTreeNode(BehaviourTree behaviourTree)
        {
            _behaviourTree = behaviourTree;
            _status = Status.Idle;
        }

        public Status ExecutionStatus()
        {
            return _status;
        }

        public void Enter()
        {
            _behaviourTree.Start();
            _status = Status.Running;
        }

        public void Execute()
        {
            if (_behaviourTree.Status() == Status.Running)
            {
                _behaviourTree.Update();
                return;
            }

            _status = _behaviourTree.Status();
        }

        public void Exit()
        {
            _behaviourTree.Reset();
            _status = Status.Idle;
        }
    }
}