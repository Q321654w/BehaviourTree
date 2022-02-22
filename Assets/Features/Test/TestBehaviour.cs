using Features.BehaviourTrees;
using Features.BehaviourTrees.Common;
using Features.BehaviourTrees.INodes;
using Features.BehaviourTrees.INodes.Implementations.Actions;
using Features.BehaviourTrees.INodes.Implementations.Composites;
using Features.BehaviourTrees.INodes.Implementations.DebugNodes;
using Features.BehaviourTrees.INodes.Implementations.Decorator;
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
            var firstNode = new CollisionNode(customCollider);
            var waitWhile = new WaitUntilFailure(firstNode);

            var secondNode = new DelayNode(new Timer(3));
            var thirdNode = new DebugNode();

            var sequence = new Sequence(new INode[]
            {
                waitWhile, secondNode, thirdNode
            });

            _behaviourTree = new BehaviourTree(sequence);
            _behaviourTree.Start();
        }

        private void Update()
        {
            if (_behaviourTree.Status() == Status.Running)
                _behaviourTree.Update();
        }
    }
}