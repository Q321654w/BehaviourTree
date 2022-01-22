namespace BehaviourTree
{
    public class ConstantNode : INode
    {
        private readonly bool _isActive;

        public ConstantNode(bool isActive)
        {
            _isActive = isActive;
        }

        public void Enter()
        {
            
        }

        public bool Execute()
        {
            return _isActive;
        }
    }
}