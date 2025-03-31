using UnityEngine;

namespace Shooter.Weapons {
    public abstract class BaseRangeWeapon : IRangeWeapon {
        protected readonly float reloadTime;
        protected int currentAmmo;
        protected readonly int maxAmmo;
        protected bool isReloading;
        private readonly float spread;
        protected readonly float range;
        protected readonly float hitDamage;

        protected BaseRangeWeapon(float reloadTime, int currentAmmo, int maxAmmo, float spread, float range, float hitDamage) {
            this.reloadTime = reloadTime;
            this.currentAmmo = currentAmmo;
            this.maxAmmo = maxAmmo;
            this.spread = spread;
            this.range = range;
            this.hitDamage = hitDamage;
        }

        public bool IsReloading => isReloading;
        public float ReloadTime => reloadTime;
        public int CurrentAmmo => currentAmmo;
        public int MaxAmmo => maxAmmo;
        public bool HasAmmo => currentAmmo > 0;
        public float Range => range;

        public float HitDamage => hitDamage;

        public virtual void ConsumeAmmo(int amount) {
            currentAmmo = System.Math.Max(currentAmmo - amount, 0);
        }

        public abstract void Reload();

        public abstract void Aim(bool status);
        public abstract void Hit(Vector3 origin, Vector3 direction);

        protected Vector3 ApplySpread(Vector3 direction) {
            float halfAngle = spread * 0.5f;
            float yaw = Random.Range(-halfAngle, halfAngle);
            float pitch = Random.Range(-halfAngle, halfAngle);
            Quaternion spreadRotation = Quaternion.Euler(pitch, yaw, 0);
            return spreadRotation * direction;
        }
    }
}