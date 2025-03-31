
using UnityEngine;

namespace Shooter.Items.Weapons {
    public abstract class BaseRangeWeapon<TSO> : BaseWeapon<TSO>, IReloadable, IAmmoUser, IAimable where TSO : WeaponWithAmmoSO {

        private bool _isReloading = false;
        private int _currentAmmo;

        protected BaseRangeWeapon(GameObject weaponPrefab, TSO weaponInfo) : base(weaponPrefab, weaponInfo) {
            _currentAmmo = weaponInfo.MaxAmmo;
        }

        public bool HasAmmo => _currentAmmo > 0;
        public override void Attack(Vector3 origin, Vector3 direction) {
            if (HasAmmo && !_isReloading) {
                base.Attack(origin, direction);
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
            throw new System.NotImplementedException();
        }
    }
}