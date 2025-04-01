using UnityEngine;

namespace Shooter.Items {
    [CreateAssetMenu(fileName = "AmmoItemSO", menuName = "Shooter/ScriptableObjects/AmmoItemSO")]
    public class AmmoItemSO : StackableItemSO {
        [SerializeField]
        [Min(0)]
        private int _bulletsCount;

        public int BulletsCount => _bulletsCount;
    }
}