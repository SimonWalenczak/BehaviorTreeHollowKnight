using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// Waiting node for a behaviour tree.
    /// This node remains in the ‘Running’ state for a defined time before returning to ‘Success’.
    /// </summary>
    class Wait : TreeNode
    {
        public float Timer { get; set; }
        private float _currentTime;

        protected override void ResetInternal()
        {
            _currentTime = 0;
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            while (_currentTime < Timer)
            {
                _currentTime += Time.deltaTime;
                return TreeNodeState.Running;
            }
            
            Reset();
            return TreeNodeState.Success;
        }
    }
}