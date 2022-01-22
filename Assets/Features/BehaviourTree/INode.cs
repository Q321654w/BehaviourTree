namespace BehaviourTree
{
    public interface INode
    {
        void Enter();
        bool Execute();
    }
}