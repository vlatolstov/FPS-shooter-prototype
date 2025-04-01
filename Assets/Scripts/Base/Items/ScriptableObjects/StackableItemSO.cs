using UnityEngine;

namespace Shooter.Items {
    public abstract class StackableItemSO : ItemSO {
        [SerializeField]
        [Min(0)]
        private int _maxStackSize;

        public int MaxStackSize => _maxStackSize;
    }
}