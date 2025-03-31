using System.Collections;
using Shooter.Weapons;

using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public IWeapon CurrentWeapon { get; private set; }

    public void ChangeWeapon(IWeapon newWeapon) {
        CurrentWeapon = newWeapon;
    }

    private void Start() {
        CurrentWeapon = new Shotgun(1, 500, 500, 40, 20, 5, 8);
    }
}
