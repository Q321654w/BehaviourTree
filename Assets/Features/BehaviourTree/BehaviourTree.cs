using System.Collections.Generic;
using System.Linq;

namespace BehaviourTree
{
    public class BehaviourTree : INode
    {
        private readonly Dictionary<INode, IEnumerable<INode>> _nodes;
        private INode _currentNode;

        private bool _isStopped;
        private bool _isActive;

        public BehaviourTree(IEnumerable<KeyValuePair<INode, IEnumerable<INode>>> nodes, INode startNode)
        {
            _isStopped = true;
            _currentNode = startNode;
            _nodes = nodes.ToDictionary(key => key.Key, element => element.Value);
        }

        public void Enter()
        {
            _isActive = true;
            _isStopped = false;
            _currentNode.Enter();
        }

        public void Resume()
        {
            _isStopped = false;
        }

        public void Stop()
        {
            _isStopped = true;
        }

        public bool Execute()
        {
            Update();
            return _isActive;
        }

        private void Update()
        {
            if (_isStopped)
                return;

            if (_currentNode.Execute())
                return;

            var transitionNodes = _nodes[_currentNode];

            foreach (var node in transitionNodes)
            {
                if (!node.Execute())
                    continue;

                _currentNode = node;
                _currentNode.Enter();
                return;
            }

            _isActive = false;
        }
    }
}