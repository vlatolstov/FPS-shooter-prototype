using UnityEngine;

namespace Shooter.Weapons {
    public interface IWeapon {
        void Hit(Vector3 origin, Vector3 direction);
    }
}