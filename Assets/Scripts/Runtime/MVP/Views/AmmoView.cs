using UnityEngine;
using UnityEngine.UI;

public class AmmoView : BaseView {
    [SerializeField] private GameObject _ammoHudGO;
    [SerializeField] private Text _ammoText;

    public void UpdateAmmoText(int current, int max) {
        string text = $"{current} / {max}";
        _ammoText.text = text;
    }

    public void EnableAmmoHUD(bool enabled) {
        _ammoHudGO.SetActive(enabled);
    }
}
