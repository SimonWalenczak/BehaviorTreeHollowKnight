using System.Collections.Generic;
using UnityEngine;

namespace Core.AI
{
    /// <summary>
    /// This class manages the execution of a decision tree by updating its root node and storing context values in a Blackboard.
    /// </summary>
    public class BehaviorTree : MonoBehaviour
    {
        public TreeNode Root { get; set; }
        private Dictionary<string, float> Blackboard { get; set; }

        private void Awake()
        {
            Blackboard = new Dictionary<string, float>();
        }

        private void Update()
        {
            if (Root != null)
                Root.Update(this, this.gameObject);
        }

        public void WriteBlackboard(string name, float value)
        {
            if (Blackboard.TryAdd(name, value))
            {
                Blackboard[name] = value;
            }
            else
            {
                Blackboard.Add(name, value);
            }
        }

        public float ReadBlackboard(string name)
        {
            return Blackboard.GetValueOrDefault(name, 0);
        }

        /// <summary>
        /// Change the current root by the repeater
        /// </summary>
        /// <param name="repeater"></param>
        internal void SetRepeater(Repeater repeater)
        {
            Root = repeater;
        }
    }
}