using Core.Character;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// Class which sets any boss's value
    /// </summary>
    public class SetBlackboard : TreeNode
    {
        public string Name;
        public float Value;

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            tree.WriteBlackboard(Name, Value);

            return TreeNodeState.Success;
        }
    }
}