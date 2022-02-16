using BehaviourTrees;
using Features.BehaviourTrees;

namespace MVQ
{
    internal class EmptyNode : INode
    {
        public void Enter()
        {
            
        }

        public bool Active()
        {
            return false;
        }

        public void Execute()
        {
        }

        public void Exit()
        {
            
        }
    }
}