using UnityEngine;

namespace Shooter.Weapons {
    public abstract class BaseRangeWeapon : BaseWeapon, IReloadable, IAmmoUser {
        protected readonly float reloadTime;
        protected bool isReloading = false;
        protected int currentAmmo;
        protected readonly int maxAmmo;

        private readonly float spread;

        protected BaseRangeWeapon(float range, float hitDamage) : base(range, hitDamage) {
        }

        public float ReloadTime => reloadTime;
        public bool IsReloading => isReloading;
        public int CurrentAmmo => currentAmmo;
        public int MaxAmmo => maxAmmo;
        public bool HasAmmo => currentAmmo > 0;
        

        public virtual void ConsumeAmmo(int amount) {
            currentAmmo = System.Math.Max(currentAmmo - amount, 0);
        }

        public abstract void Reload();

        public abstract void Aim(bool status);

        protected Vector3 ApplySpread(Vector3 direction) {
            float halfAngle = spread * 0.5f;
            float yaw = Random.Range(-halfAngle, halfAngle);
            float pitch = Random.Range(-halfAngle, halfAngle);
            Quaternion spreadRotation = Quaternion.Euler(pitch, yaw, 0);
            return spreadRotation * direction;
        }
    }
}