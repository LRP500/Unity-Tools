using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0414

namespace Tools.Navigation
{
    [CreateAssetMenu(menuName = "Tools/Navigation/Game Screen")]
    public class GameScreen : SerializedScriptableObject
    {
        [SerializeField]
        private HashSet<SceneReference> _scenes = null;
        public HashSet<SceneReference> Scenes => _scenes;

        [SerializeField]
        private HashSet<SceneReference> _dependencies = null;
    }
}
