using UnityEngine;

namespace Shooter.Weapons {
    public abstract class BaseWeapon : BaseItem, IWeapon {
        protected readonly float range;
        protected readonly float hitDamage;

        protected BaseWeapon(float range, float hitDamage) {
            this.range = range;
            this.hitDamage = hitDamage;
        }

        public float Range => range;

        public float HitDamage => hitDamage;

        public abstract void Hit(Vector3 origin, Vector3 direction);
    }
}