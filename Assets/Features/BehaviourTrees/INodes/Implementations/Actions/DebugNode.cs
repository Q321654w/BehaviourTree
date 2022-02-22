using UnityEngine;

namespace Features.BehaviourTrees.INodes.Implementations.Actions
{
    public class DebugNode : INode
    {
        private Status _status;

        public DebugNode()
        {
            _status = Status.Idle;
        }
        
        public Status ExecutionStatus()
        {
            return _status;
        }

        public void Enter()
        {
            _status = Status.Success;
            Debug.Log("Debug Node Entered");
        }

        public void Execute()
        {
        }

        public void Exit()
        {
            _status = Status.Idle;
        }
    }
}