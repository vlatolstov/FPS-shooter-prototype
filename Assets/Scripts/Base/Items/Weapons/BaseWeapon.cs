using Shooter.Health;

using UnityEngine;

namespace Shooter.Items.Weapons {
    public abstract class BaseWeapon<TSO> : BaseItem<TSO>, IWeapon where TSO : WeaponSO {

        private float _nextHitTime = 0f;

        protected BaseWeapon(GameObject weaponPrefab, TSO weaponInfo) : base(weaponPrefab, weaponInfo) {
        }

        public virtual void Attack(Vector3 origin, Vector3 direction) {
            if (CanHit()) {
                Hit(origin, direction);
            }
        }

        protected virtual void Hit(Vector3 origin, Vector3 direction) {
            Vector3 modifiedDirection = ApplySpread(direction);
            if (Physics.Raycast(origin, modifiedDirection, out RaycastHit hit, ItemInfo.Range)) {
                var health = hit.collider.GetComponent<IHaveHealth>();
                health?.ChangeHealth(-ItemInfo.Damage);
            }
        }

        private bool CanHit() {
            if (Time.time < _nextHitTime)
                return false;

            _nextHitTime = Time.time + (1f / ItemInfo.AttackRate);
            return true;
        }

        private Vector3 ApplySpread(Vector3 direction) {
            float halfAngle = ItemInfo.Spread * 0.5f;
            float yaw = Random.Range(-halfAngle, halfAngle);
            float pitch = Random.Range(-halfAngle, halfAngle);
            Quaternion spreadRotation = Quaternion.Euler(pitch, yaw, 0);
            return spreadRotation * direction;
        }
    }
}