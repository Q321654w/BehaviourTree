using Features.BehaviourTrees;
using UnityEngine;

 namespace BehaviourTrees
{
    public class DebugNode : INode
    {
        private bool _isActive;

        public DebugNode()
        {
            _isActive = true;
        }

        public bool Active()
        {
            return _isActive;
        }

        public void Enter()
        {
            _isActive = false;
            Debug.Log("Debug Node Entered");
        }

        public void Execute()
        {
        }

        public void Exit()
        {
            _isActive = true;
        }
    }
}