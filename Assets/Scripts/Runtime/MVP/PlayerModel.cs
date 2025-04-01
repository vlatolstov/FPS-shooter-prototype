using Zenject;

public class PlayerModel : BaseModel<PlayerDataContainer>, ITickable {

    public PlayerModel(PlayerDataContainer container, PlayerWeaponController weaponController) : base(container) {
        
    }

    public InventoryData GetInventoryData() {
        return DataContainer.GetData<InventoryData>();
    }

    //public void SetCurrentWeapon(InventoryWeapon weapon) {
    //    ChangeData<InventoryData>((inventoryData, container) => {
    //        inventoryData.EquippedWeapon = weapon;
    //    });
    //}

    public void Tick() {
        
    }
}
