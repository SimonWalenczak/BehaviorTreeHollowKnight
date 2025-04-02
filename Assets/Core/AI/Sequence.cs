using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// Node that checks each of its children in order. If one of them is wrong, it doesn't move on to the next one.
    /// </summary>
    public class Sequence : TreeNode
    {
        public Sequence()
        {
            Children = new List<TreeNode>();
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            bool anyChildIsRunning = false;

            foreach (TreeNode child in Children)
            {
                switch (child.Update(tree, owner))
                {
                    case TreeNodeState.Failed:
                        Reset();
                        return TreeNodeState.Failed;

                    case TreeNodeState.Success:
                        continue;

                    case TreeNodeState.Running:
                        anyChildIsRunning = true;
                        continue;
                }
            }

            if (anyChildIsRunning)
                return TreeNodeState.Running;
            else
            {
                Reset();
                return TreeNodeState.Success;
            }
        }
    }
}