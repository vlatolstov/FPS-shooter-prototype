using UnityEngine;

public abstract class BaseItem {
    protected abstract GameObject ItemPrefab { get; }
    protected abstract ItemSO ItemInfo { get; }
}
