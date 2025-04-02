
using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// Represents a node in a behaviour tree. It can have several children and executes its logic by updating them.
    /// This class is used as the basis for the different types of node in a BehaviorTree.
    /// </summary>
    public class TreeNode
    {
        public List<TreeNode> Children { get; set; }

        public void Add(TreeNode node)
        {
            Children.Add(node);
        }


        public virtual TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            return Children[0].Update(tree, owner);
        }

        /// <summary>
        /// Used to reset all variables
        /// </summary>
        public void Reset()
        {
            ResetInternal();

            if (Children != null)
            {
                foreach (var item in Children)
                {
                    item.Reset();
                }
            }
        }

        protected virtual void ResetInternal()
        {
            
        }
    }

    public enum TreeNodeState
    {
        Idle,
        Success,
        Failed,
        Running
    }

}
