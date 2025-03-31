using Shooter.Items;
using Shooter.Items.Weapons;

using UnityEngine;

public class RangeWeapon : BaseRangeWeapon<WeaponWithAmmoSO> {
    public RangeWeapon(GameObject weaponPrefab, WeaponWithAmmoSO weaponInfo) : base(weaponPrefab, weaponInfo) {
    }
}
