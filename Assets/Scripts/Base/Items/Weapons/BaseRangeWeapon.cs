
using System.Collections;

using NUnit.Framework.Constraints;

using UnityEngine;

namespace Shooter.Items.Weapons {
    public abstract class BaseRangeWeapon<TSO> : BaseWeapon<TSO>, IReloadable, IAmmoUser, IAimable where TSO : WeaponWithAmmoSO {

        private float _reloadingTimestamp = 0f;
        private int _currentAmmo;

        public bool IsReloading => ItemInfo.ReloadTime + _reloadingTimestamp < Time.time;

        protected BaseRangeWeapon(GameObject weaponPrefab, TSO weaponInfo) : base(weaponPrefab, weaponInfo) {
            _currentAmmo = weaponInfo.MaxAmmo;
        }

        public bool HasAmmo => _currentAmmo > 0;
        public override void Attack(Vector3 origin, Vector3 direction, MuzzleParticle muzzleParticle = null) {
            if (HasAmmo && !IsReloading) {
                base.Attack(origin, direction, muzzleParticle);
            }
        }

        protected override void Hit(Vector3 origin, Vector3 direction) {
            for (int i = 0; i < ItemInfo.HitsPerAmmo; i++) {
                base.Hit(origin, direction);
            }
            ConsumeAmmo(1);
        }

        public virtual void ConsumeAmmo(int amount) {
            _currentAmmo = System.Math.Max(_currentAmmo - amount, 0);
        }


        public void Aim() {
            throw new System.NotImplementedException();
        }

        public void Reload() {
            if (IsReloading) {
                _currentAmmo = ItemInfo.MaxAmmo;
                _reloadingTimestamp = Time.time;
            }
        }
    }
}