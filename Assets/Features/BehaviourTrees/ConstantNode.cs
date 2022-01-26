﻿﻿ namespace BehaviourTrees
{
    public class ConstantNode : INode
    {
        private readonly bool _isActive;

        public ConstantNode(bool isActive)
        {
            _isActive = isActive;
        }

        public bool IsActive()
        {
            return _isActive;
        }

        public void Enter()
        {
            
        }

        public void Execute()
        {
           
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}