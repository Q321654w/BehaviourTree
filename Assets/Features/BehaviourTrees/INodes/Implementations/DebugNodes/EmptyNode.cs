namespace Features.BehaviourTrees.INodes.Implementations.DebugNodes
{
    public class EmptyNode : INode
    {
        public Status ExecutionStatus()
        {
            return Status.Idle;
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