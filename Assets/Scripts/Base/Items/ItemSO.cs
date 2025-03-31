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


        public Vector2 InventorySize { get => _inventorySize; }
        public Sprite Icon { get => _icon; }
        public string Name { get => _name; }
        public string Description { get => _description; }
        public GameObject ItemPrefab { get => _itemPrefab; }
    }

    public abstract class StackableItem : ItemSO {
        [SerializeField]
        [Min(0)]
        private int _maxStackSize;

        public int MaxStackSize { get => _maxStackSize; }
    }

    [CreateAssetMenu(fileName = "AmmoItemSO", menuName = "Shooter/ScriptableObjects/AmmoItemSO")]
    public class AmmoItemSO : ItemSO {
        [SerializeField]
        [Min(0)]
        private int _maxStackSize;

        public int MaxStackSize { get => _maxStackSize; }
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

        public float Damage { get => _damage; }
        public float Range { get => _range; }
        public float AttackRate { get => _attackRate; }
        public float Spread { get => _spread; }
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

        public int MaxAmmo { get => _maxAmmo; }
        public int HitsPerAmmo { get => _hitsPerAmmo; }
        public float ReloadTime { get => _reloadTime; }
        public AmmoType AmmoType { get => _ammoType; }
    }

    public enum AmmoType {
        Shotgun,
        Rifle,
        Pistol
    }
}