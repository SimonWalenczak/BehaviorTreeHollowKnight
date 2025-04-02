
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// Node which can be called anywhere to debug
    /// </summary>
    class Log : TreeNode
    {
        public string Text { get; set; }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            Debug.Log(Text);

            return TreeNodeState.Success;
        }
    }
}
