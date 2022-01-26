using System.Collections.Generic;

namespace BehaviourTrees
{
    public class WhileAllNode : NodeSequenceDecorator
    {
        public WhileAllNode(IEnumerable<INode> nodes) : base(nodes)
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
            foreach (var node in Nodes)
            {
                if (node.IsActive())
                    continue;
                
                return false;
            }

            return true;
        }

        public override void Execute()
        {
            foreach (var node in Nodes)
            {
                node.Execute();
            }
        }

        public override void Exit()
        {
            foreach (var node in Nodes)
            {
                node.Exit();
            }
        }
    }
}