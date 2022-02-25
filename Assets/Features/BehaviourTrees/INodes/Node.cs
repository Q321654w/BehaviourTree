namespace Features.BehaviourTrees.INodes.Implementations.Actions
{
    public abstract class Node : INode
    {
        protected Status Status;

        public Node()
        {
            Status = Status.Idle;
        }

        public Status ExecutionStatus()
        {
            return Status;
        }

        public abstract void Enter();

        public abstract void Execute();

        public abstract void Exit();

    }
}