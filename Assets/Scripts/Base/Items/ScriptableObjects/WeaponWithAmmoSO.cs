using UnityEngine;

namespace Shooter.Items {
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
}