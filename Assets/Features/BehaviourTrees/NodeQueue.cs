using System.Collections.Generic;

namespace BehaviourTrees
{
    public class NodeQueue : NodeSequenceDecorator
    {
        private int _currentIndex;

        public NodeQueue(IEnumerable<INode> nodes) : base(nodes)
        {
        }

        public override void Enter()
        {
            foreach (var node in Nodes)
            {
                node.Enter();
            }
        }

        public override bool IsActive()
        {
            return _currentIndex >= NodeCollectionLength;
        }

        public override void Execute()
        {
            var currentNode = Nodes[_currentIndex];

            if (currentNode.IsActive())
            {
                currentNode.Execute();
                return;
            }

            _currentIndex++;
        }

        public override void Exit()
        {
            foreach (var node in Nodes)
            {
                node.Exit();
            }

            Reset();
        }

        private void Reset()
        {
            _currentIndex = 0;
        }
    }
}