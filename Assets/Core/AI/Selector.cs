using System.Collections.Generic;
using System.Resources;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// Node that checks each of its children in order. As long as the current child is true, it does not move on to the next.
    /// </summary>
    public class Selector : TreeNode
    {
        public Selector()
        {
            Children = new List<TreeNode>();
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            foreach (TreeNode child in Children)
            {
                switch (child.Update(tree, owner))
                {
                    case TreeNodeState.Failed:
                        continue;
                    
                    case TreeNodeState.Success:
                        Reset();
                        return TreeNodeState.Success;
                    
                    case TreeNodeState.Running:
                        return TreeNodeState.Running;
                }
            }

            Reset();
            return TreeNodeState.Failed;
        }
    }
}