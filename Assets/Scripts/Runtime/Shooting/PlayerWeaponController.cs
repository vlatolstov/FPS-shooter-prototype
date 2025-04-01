using Shooter.Items;
using Shooter.Items.Weapons;

using UnityEngine;

using Zenject;

public class PlayerWeaponController : MonoBehaviour {

    [SerializeField] private Transform _weaponSocket;
    [SerializeField] private GameObject _shotgunPrefab;
    //[Inject] private PlayerModel _playerModel;
    public IWeapon CurrentWeapon { get; private set; }

    public void ChangeWeapon(IWeapon newWeapon) {
        CurrentWeapon = newWeapon;
        var baseItem = (newWeapon as BaseItem<WeaponWithAmmoSO>);
        InstallWeapon(baseItem.ItemInfo);
        //_playerModel.SetCurrentWeapon(baseItem.InventoryItem);
    }

    private void InstallWeapon(WeaponSO weaponPrefab) {
        UninstallWeapon();
        var weapon = Instantiate(weaponPrefab.ItemPrefab, _weaponSocket);
        weapon.transform.SetLocalPositionAndRotation(weaponPrefab.EquippedPosition, Quaternion.Euler(weaponPrefab.EquippedRotation));
    }

    private void UninstallWeapon() {
        if (_weaponSocket.childCount != 0) {
            for (int i = 0; i < _weaponSocket.childCount; i++) {
                var child = _weaponSocket.GetChild(i).gameObject;
                Destroy(child);
            }
        }
    }
}
