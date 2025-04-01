using UnityEngine;

namespace Shooter.Items.Weapons {
    public interface IWeapon {
        void Attack(Vector3 origin, Vector3 direction, MuzzleParticle muzzleParticle = null);
    }
}