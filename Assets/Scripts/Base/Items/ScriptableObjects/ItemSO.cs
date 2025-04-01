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
}