using Shooter.Weapons;

using UnityEngine;

using Zenject;

public class PlayerWeaponController : MonoBehaviour {

    [SerializeField] private Transform _weaponSocket;
    [SerializeField] private GameObject _shotgunPrefab;
    [Inject] private PlayerModel _playerModel;
    public IWeapon CurrentWeapon { get; private set; }

    public void ChangeWeapon(IWeapon newWeapon) {
        CurrentWeapon = newWeapon;
        var baseItem = (newWeapon as BaseItem);
        //InstallWeapon(baseItem.ItemPrefab);
        //_playerModel.SetCurrentWeapon(baseItem.InventoryItem);
    }

    private void Start() {
        //var shotgun = new Shotgun(1, 8, 10, 20, 15, 10, _shotgunPrefab, 8);
        //ChangeWeapon(shotgun);
    }

    private void InstallWeapon(GameObject weaponPrefab) {
        UninstallWeapon();
        Instantiate(weaponPrefab, _weaponSocket);
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
