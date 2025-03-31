using System.Collections.Generic;

using Shooter.Health;

using UnityEngine;

namespace Shooter.Weapons {
    public class Shotgun : BaseRangeWeapon {
        private readonly int _hitsPerBullet;

        public Shotgun(float range, float hitDamage) : base(range, hitDamage) {
        }

        protected override GameObject ItemPrefab => throw new System.NotImplementedException();

        protected override ItemSO ItemInfo => throw new System.NotImplementedException();

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

            ConsumeAmmo(1);
        }

        public override void Reload() {
            throw new System.NotImplementedException();
        }
    }
}