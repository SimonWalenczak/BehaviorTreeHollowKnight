using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// Node which repeat a node's suite and becomes the new root on call.
    /// </summary>
    public class Repeater : TreeNode
    {
        public int RepeatCount = -1;
        private int _currentRepeatCount = 0;
        
        public Repeater()
        {
            Children = new List<TreeNode>();
        }

        protected override void ResetInternal()
        {
            _currentRepeatCount = 0;
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            tree.SetRepeater(this);
            
            if (RepeatCount == -1 && _currentRepeatCount >= RepeatCount)
                return TreeNodeState.Success;

            TreeNode child = Children[0];
            TreeNodeState result = child.Update(tree, owner);

            if (result == TreeNodeState.Success || result == TreeNodeState.Failed)
                _currentRepeatCount++;

            return TreeNodeState.Running;
        }
    }
}