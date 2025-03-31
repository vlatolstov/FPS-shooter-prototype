using System.Collections;
using System.Collections.Generic;

using Shooter.Health;
using Shooter.Weapons;

using UnityEngine;

public class PlayerDataContainer : BaseDataContainer {
    
    public PlayerDataContainer(IEnumerable<IData> data) : base(data) {
    }
}

public class InventoryData : IData {
    public List<InventoryItem> Items;
}


public class InventoryItem  {
    public Vector2 InventorySize;
    public Sprite Icon;
    public string Name;
    public string Description;

    public InventoryItem(Vector2 inventorySize, Sprite icon, string name, string description) {
        InventorySize = inventorySize;
        Icon = icon;
        Name = name;
        Description = description;
    }
}


public class HealthData : IData {
    public Health Health;
}
