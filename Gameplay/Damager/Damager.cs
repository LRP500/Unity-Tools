using UnityEngine;

namespace Tools.Gameplay
{
    public class Damager : MonoBehaviour
    {
        [SerializeField]
        public bool _canDamage = true;

        [SerializeField]
        public bool _applyOnTriggerEnter = true;

        [SerializeField]
        private float _damage = 0f;
        public float Damage => _damage;

        private System.Action<float> OnApplyDamage = null;

        public void SetDamage(float damage)
        {
            _damage = damage;
        }

        public void ApplyDamage(Damageable damageable, float damageValue)
        {
            if (_canDamage && damageable)
            {
                damageable.TakeDamage(damageValue);
            }
        }

        public void Apply(Collider other)
        {
            Apply(other.gameObject.GetComponent<Damageable>());
        }

        public void Apply(Damageable damageable)
        {
            ApplyDamage(damageable, _damage);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_applyOnTriggerEnter)
            {
                Apply(other);
            }
        }

        public void Register(System.Action<float> callback)
        {
            OnApplyDamage += callback;
        }

        public void Unregister(System.Action<float> callback)
        {
            OnApplyDamage -= callback;
        }
    }
}
