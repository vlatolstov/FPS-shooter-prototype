using Shooter.Items;

using UnityEngine;

public class PickupProcessor : MonoBehaviour {
    [SerializeField] private GameObject _itemGO;
    [SerializeField] private ItemSO _itemSO;

    public void Pickup(GameObject actor) {
        if (!actor.TryGetComponent<PlayerWeaponController>(out var weaponController)) {
#if UNITY_EDITOR
            Debug.LogAssertion($"Can't pickup this! Actor don't have weaponController");
#endif
        }

        if (_itemSO is WeaponWithAmmoSO weaponWithAmmo) {
            weaponController.ChangeWeapon(new RangeWeapon(_itemGO, weaponWithAmmo));
        }
        else {
#if UNITY_EDITOR
            Debug.LogAssertion($"Not implemented pickup type");
#endif
        }

        Destroy(gameObject);
    }

    public string GetPickupInfo() {
        return _itemSO.Name;
    }
}
