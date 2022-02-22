namespace Features.BehaviourTrees.INodes.Implementations.Decorator
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
            _status = Status.Running;
            _behaviourTree.Start();
        }

        public void Execute()
        {
            if (_behaviourTree.Status() == Status.Running)
                _behaviourTree.Update();

            _status = _behaviourTree.Status();
        }

        public void Exit()
        {
            _behaviourTree.Reset();
            _status = Status.Idle;
        }
    }
}