using System.Collections.Generic;
using UnityEngine;

namespace Tools.Persistence
{
    [CreateAssetMenu(menuName = "Tools/Tables/String Table")]
    public class ClubTable : Table<string>
    {
        [System.Serializable]
        public class StringEntry : Entry { }

        public List<StringEntry> _table = new List<StringEntry>();
    }
}