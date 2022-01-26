using System.Collections.Generic;
using BehaviourTrees;
using UnityEngine;

namespace Features.Test
{
    public class TestBehaviour : MonoBehaviour
    {
        [SerializeField] private CustomCollider _colliderPrefab;

        private BehaviourTree _behaviourTree;

        private void Awake()
        {
            var customCollider = Instantiate(_colliderPrefab);
            var startNode = new CollisionNode(customCollider);
            var secondNode = new DelayNode(new Timer(3));
            var thirdNode = new DebugNode();

            var nodes = new Dictionary<INode, IEnumerable<INode>>();
            nodes.Add(startNode, new List<INode>()
            {
                secondNode
            });
            nodes.Add(secondNode, new List<INode>()
            {
                thirdNode
            });
            nodes.Add(thirdNode, new List<INode>());

            _behaviourTree = new BehaviourTree(nodes, startNode);
            _behaviourTree.Start();
        }

        private void Update()
        {
            if (_behaviourTree.IsActive())
                _behaviourTree.Update();
        }
    }
}