using UnityEngine;

namespace Shooter.Weapons {
    public abstract class BaseWeapon : IWeapon {
        protected GameObject weaponPrefab;
        protected readonly float range;
        protected readonly float hitDamage;

        protected BaseWeapon(float hitDamage, float range, GameObject weaponPrefab) {
            this.hitDamage = hitDamage;
            this.range = range;
            this.weaponPrefab = weaponPrefab;
        }

        public float Range => range;

        public float HitDamage => hitDamage;

        public GameObject WeaponPrefab => weaponPrefab;

        public abstract void Hit(Vector3 origin, Vector3 direction);
    }
}