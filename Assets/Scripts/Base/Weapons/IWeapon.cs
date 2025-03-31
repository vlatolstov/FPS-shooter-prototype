using UnityEngine;

namespace Shooter.Weapons {
    public interface IWeapon {
        float Range { get; }
        float HitDamage { get; }
        void Hit(Vector3 origin, Vector3 direction);
    }
}