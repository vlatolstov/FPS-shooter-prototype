using UnityEngine;

namespace Shooter.Items {
    [CreateAssetMenu(fileName = "WeaponSO", menuName = "Shooter/ScriptableObjects/WeaponSO")]
    public class WeaponSO : ItemSO {
        [SerializeField]
        [Min(0)]
        private float _damage;
        [SerializeField]
        [Min(0)]
        private float _range;
        [SerializeField]
        [Min(0)]
        [Tooltip("Per second.")]
        private float _attackRate;
        [SerializeField]
        [Range(0, 90)]
        private float _spread;
        [SerializeField]
        private Vector3 _equippedPosition;
        [SerializeField]
        private Vector3 _equippedRotation;
        [SerializeField]
        private GameObject _hitParticle;

        public float Damage => _damage;
        public float Range => _range;
        public float AttackRate => _attackRate;
        public float Spread => _spread;
        public Vector3 EquippedPosition => _equippedPosition;
        public Vector3 EquippedRotation => _equippedRotation;
        public GameObject HitParticle => _hitParticle;
    }
}