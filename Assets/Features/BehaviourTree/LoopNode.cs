namespace BehaviourTree
{
    public class LoopNode : NodeDecorator
    {
        private readonly int _loops;
        private int _currentLoop;

        public LoopNode(INode childNode, int loops) : base(childNode)
        {
            _loops = loops;
            _currentLoop = 0;
        }

        public override void Enter()
        {
            ChildNode.Enter();
            Reset();
        }

        public override bool Execute()
        {
            if (ChildNode.Execute())
                return true;

            if (_currentLoop >= _loops)
                return false;

            _currentLoop++;

            return true;
        }

        private void Reset()
        {
            _currentLoop = 0;
        }
    }
}