using Features.BehaviourTrees.INodes;

namespace Features.BehaviourTrees
{
    public class BehaviourTree
    {
        private readonly INode _rootNode;

        public BehaviourTree(INode rootNode)
        {
            _rootNode = rootNode;
        }

        public void Start()
        {
            _rootNode.Enter();
        }

        public Status Status()
        {
            return _rootNode.ExecutionStatus();
        }

        public void Update()
        {
            _rootNode.Execute();
        }

        public void Reset()
        {
            _rootNode.Exit();
        }
    }
}