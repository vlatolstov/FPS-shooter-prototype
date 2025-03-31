using Shooter.Items;
using Shooter.Items.Weapons;

using UnityEngine;

public class MeleeWeapon : BaseWeapon<WeaponSO> {
    public MeleeWeapon(GameObject weaponPrefab, WeaponSO weaponInfo) : base(weaponPrefab, weaponInfo) {
    }
}
