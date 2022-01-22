using System.Collections.Generic;

namespace BehaviourTree
{
    public class WhileAllNode : NodeSequenceDecorator
    {
        public WhileAllNode(IEnumerable<INode> nodes) : base(nodes)
        {
        }

        protected override void InternalEnter()
        {
        }

        public override bool Execute()
        {
            var isActive = true;
            
            foreach (var node in Nodes)
            {
                isActive &= node.Execute();
            }

            return isActive;
        }
    }
}