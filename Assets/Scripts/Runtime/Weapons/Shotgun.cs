using System.Collections.Generic;

using Shooter.Health;

using UnityEngine;

namespace Shooter.Weapons {
    public class Shotgun : BaseRangeWeapon {
        private readonly int _hitsPerBullet;

        public Shotgun(float reloadTime, int currentAmmo, int maxAmmo, float spread, float range, float hitDamage, int hitsPerBullet) : base(reloadTime, currentAmmo, maxAmmo, spread, range, hitDamage) {
            _hitsPerBullet = hitsPerBullet;
        }

        public override void Aim(bool status) {
            throw new System.NotImplementedException();
        }

        public override void Hit(Vector3 origin, Vector3 direction) {
            if (isReloading || !HasAmmo) {
                return;
            }

            List<RaycastHit> output = new();

            for (int i = 0; i < _hitsPerBullet; i++) {
                Vector3 modifiedDirection = ApplySpread(direction);
                if (Physics.Raycast(origin, modifiedDirection, out RaycastHit hit, Range)) {
                    output.Add(hit);
                }
            }

            foreach (var hit in output) {
                var health = hit.collider.GetComponent<IHaveHealth>();
                health?.ChangeHealth(-hitDamage);
            }
        }

        public override void Reload() {
            throw new System.NotImplementedException();
        }
    }
}