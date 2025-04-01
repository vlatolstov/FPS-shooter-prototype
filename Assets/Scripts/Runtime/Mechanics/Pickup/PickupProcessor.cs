using Shooter.Items;

using UnityEngine;

public class PickupProcessor : MonoBehaviour {
    [SerializeField] private ItemSO _itemSO;

    public void Pickup(GameObject actor) {
        if (!actor.TryGetComponent<PlayerWeaponController>(out var weaponController)) {
            return;
        }

        if (_itemSO is WeaponWithAmmoSO weaponWithAmmo) {
            weaponController.ChangeWeapon(new RangeWeapon(weaponWithAmmo.ItemPrefab, weaponWithAmmo));
        }
        else {
            return;
        }

        Destroy(gameObject);
    }

    public string GetPickupInfo() {
        return _itemSO.Name;
    }
}
