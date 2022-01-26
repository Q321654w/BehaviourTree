using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BehaviourTrees
{
    public class BehaviourTree
    {
        private readonly Dictionary<INode, IEnumerable<INode>> _nodes;
        private readonly INode _startNode;

        private INode _currentNode;
        private bool _isEnded;

        public BehaviourTree(IEnumerable<KeyValuePair<INode, IEnumerable<INode>>> nodes, INode startNode)
        {
            _startNode = startNode;
            _currentNode = startNode;
            _nodes = nodes.ToDictionary(key => key.Key, element => element.Value);
        }

        public void Start()
        {
            _currentNode.Enter();
            _isEnded = false;
        }

        public bool IsActive()
        {
            return !_isEnded;
        }

        public void Update()
        {
            if (_currentNode.IsActive())
            {
                _currentNode.Execute();
                return;
            }

            if (!_nodes.ContainsKey(_currentNode))
                _isEnded = true;
            
            var transitionNodes = _nodes[_currentNode];

            var i = 0;
            
            foreach (var node in transitionNodes)
            {
                i++;
                
                if (!node.IsActive())
                    continue;

                _currentNode = node;
                _currentNode.Enter();
                return;
            }

            if (i == 0)
                _isEnded = true;
        }

        public void Reset()
        {
            _currentNode = _startNode;
        }
    }
}