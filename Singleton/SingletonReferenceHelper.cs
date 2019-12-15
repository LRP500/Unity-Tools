using Tools.Navigation;
using UnityEngine;

#pragma warning disable CS0414

namespace Tools
{
    public class SingletonReferenceHelper : MonoBehaviour
    {
        [SerializeField]
        private EventManager _eventManager = null;

        [SerializeField]
        private NavigationManager _navigationManager = null;
    }
}
