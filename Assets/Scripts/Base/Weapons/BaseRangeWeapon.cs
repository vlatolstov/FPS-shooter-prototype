using System;

namespace Shooter.Weapons {
    public abstract class BaseRangeWeapon : IRangeWeapon {
        protected float reloadTime;
        protected int currentAmmo;
        protected int maxAmmo;
        protected bool isReloading;
        protected float spread;

        public bool IsReloading => isReloading;
        public float ReloadTime => reloadTime;
        public int CurrentAmmo => currentAmmo;
        public int MaxAmmo => maxAmmo;
        public bool HasAmmo => currentAmmo > 0;


        public virtual void ConsumeAmmo(int amount) {
            currentAmmo = Math.Max(currentAmmo - amount, 0);
        }

        public abstract void Hit();

        public abstract void Reload();

        public abstract void Aim(bool status);
    }
}