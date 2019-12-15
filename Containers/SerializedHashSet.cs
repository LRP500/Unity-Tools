using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public abstract class SerializedHashSet<TValue> : HashSet<TValue>, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<TValue> valueData = new List<TValue>();

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            Clear();
            for (int i = 0, length = valueData.Count; i < length; i++)
            {
                Add(valueData[i]);
            }
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            valueData.Clear();

            foreach (var item in this)
            {
                valueData.Add(item);
            }
        }
    }
}