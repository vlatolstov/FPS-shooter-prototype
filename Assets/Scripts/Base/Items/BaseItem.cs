using UnityEngine;

namespace Shooter.Items {
    public abstract class BaseItem<TSO> where TSO : ItemSO {
        public GameObject ItemPrefab { get; protected set; }
        public TSO ItemInfo { get; protected set; }

        protected BaseItem(GameObject itemPrefab, TSO itemInfo) {
            ItemPrefab = itemPrefab;
            ItemInfo = itemInfo;
        }
    }
}