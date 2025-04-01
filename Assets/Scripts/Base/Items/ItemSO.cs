using UnityEngine;

namespace Shooter.Items {
    public abstract class ItemSO : ScriptableObject {
        [SerializeField]
        [Min(0)]
        private Vector2 _inventorySize;
        [SerializeField]
        private Sprite _icon;
        [SerializeField]
        private string _name;
        [SerializeField]
        private string _description;
        [SerializeField]
        private GameObject _itemPrefab;


        public Vector2 InventorySize => _inventorySize;
        public Sprite Icon => _icon;
        public string Name => _name;
        public string Description => _description;
        public GameObject ItemPrefab => _itemPrefab;
    }

    public abstract class StackableItem : ItemSO {
        [SerializeField]
        [Min(0)]
        private int _maxStackSize;

        public int MaxStackSize => _maxStackSize;
    }

    [CreateAssetMenu(fileName = "AmmoItemSO", menuName = "Shooter/ScriptableObjects/AmmoItemSO")]
    public class AmmoItemSO : StackableItem {
        [SerializeField]
        [Min(0)]
        private int _bulletsCount;

        public int BulletsCount => _bulletsCount;
    }

    [CreateAssetMenu(fileName = "WeaponSO", menuName = "Shooter/ScriptableObjects/WeaponSO")]
    public class WeaponSO : ItemSO {
        [SerializeField]
        [Min(0)]
        private float _damage;
        [SerializeField]
        [Min(0)]
        private float _range;
        [SerializeField]
        [Min(0)]
        [Tooltip("Per second.")]
        private float _attackRate;
        [SerializeField]
        [Range(0, 90)]
        private float _spread;
        [SerializeField]
        private Vector3 _equippedPosition;
        [SerializeField]
        private Vector3 _equippedRotation;

        public float Damage => _damage;
        public float Range => _range;
        public float AttackRate => _attackRate;
        public float Spread => _spread;

        public Vector3 EquippedPosition => _equippedPosition;
        public Vector3 EquippedRotation => _equippedRotation;
    }

    [CreateAssetMenu(fileName = "WeaponWithAmmoSO", menuName = "Shooter/ScriptableObjects/WeaponWithAmmoSO")]
    public class WeaponWithAmmoSO : WeaponSO {
        [SerializeField]
        [Min(0)]
        private int _maxAmmo;
        [SerializeField]
        [Min(1)]
        private int _hitsPerAmmo;
        [SerializeField]
        [Min(0)]
        private float _reloadTime;
        [SerializeField]
        private AmmoType _ammoType;

        public int MaxAmmo => _maxAmmo;
        public int HitsPerAmmo => _hitsPerAmmo;
        public float ReloadTime => _reloadTime;
        public AmmoType AmmoType => _ammoType;
    }

    public enum AmmoType {
        Shotgun,
        Rifle,
        Pistol
    }
}