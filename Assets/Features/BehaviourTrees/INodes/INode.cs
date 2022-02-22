namespace Features.BehaviourTrees.INodes
{
    public interface INode
    {
        Status ExecutionStatus();
        void Enter();
        void Execute();
        void Exit();
    }
}