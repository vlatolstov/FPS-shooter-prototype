using System;

using Zenject;

public class PlayerPresenter : BasePresenter<PlayerModel>, IInitializable, IDisposable {

    private AmmoView _ammoView;
    public PlayerPresenter(PlayerModel model, IViewsContainer viewsContainer) : base(model, viewsContainer) {
    }

    void UpdateAmmoView() {
        //var weaponInfo = Model.GetInventoryData().EquippedWeapon.Weapon;
        //if (weaponInfo is BaseRangeWeapon range) {
        //    _ammoView.EnableAmmoHUD(true);
        //    _ammoView.UpdateAmmoText(range.CurrentAmmo, range.MaxAmmo);
        //}
        //else {
        //    _ammoView.EnableAmmoHUD(false);
        //}
    }

    void OnInventoryDataChange() {
        UpdateAmmoView();
    }

    public void Initialize() {
        _ammoView = ViewsContainer.GetView<AmmoView>();
        Model.Subscribe<InventoryData>(OnInventoryDataChange);
    }

    public void Dispose() {
        Model.Unsubscribe<InventoryData>(OnInventoryDataChange);
    }
}
