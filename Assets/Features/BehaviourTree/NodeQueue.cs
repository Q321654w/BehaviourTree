using System.Collections.Generic;

namespace BehaviourTree
{
    public class NodeQueue : NodeSequenceDecorator
    {
        private int _currentIndex;
        
        public NodeQueue(IEnumerable<INode> nodes) : base(nodes)
        {
        }

        protected override void InternalEnter()
        {
            Reset();
        }

        private void Reset()
        {
            _currentIndex = 0;
        }

        public override bool Execute()
        {
            if (_currentIndex >= NodeCollectionLength)
                return false;
            
            if (Nodes[_currentIndex].Execute())
                return true;
            
            _currentIndex++;
            return true;
        }
    }
}