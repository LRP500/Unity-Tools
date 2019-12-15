using UnityEngine;

namespace Tools.Gameplay
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField]
        private bool _isDamageable = true;

        private System.Action<float> OnTakeDamage = null;

        public void TakeDamage(float damageValue)
        {
            if (_isDamageable)
            {
                OnTakeDamage?.Invoke(damageValue);
            }
        }

        public void Register(System.Action<float> callback)
        {
            OnTakeDamage += callback;
        }

        public void Unregister(System.Action<float> callback)
        {
            OnTakeDamage -= callback;
        }
    }
}
