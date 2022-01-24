using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public class TestBehaviour : MonoBehaviour
    {
        [SerializeField] private CustomCollider _colliderPrefab;

        private BehaviourTree _behaviourTree;

        private void Awake()
        {
            var customCollider = Instantiate(_colliderPrefab);
            var startNode = new CollisionNode(customCollider);
            var alwaysDisabledNode = new ConstantNode(false);
            var secondNode = new DelayedNode(alwaysDisabledNode, new Timer(3));
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

            _behaviourTree = new BehaviourTree(nodes, startNode);
            _behaviourTree.Enter();
        }

        private void Update()
        {
            _behaviourTree.Execute();
        }
    }
}