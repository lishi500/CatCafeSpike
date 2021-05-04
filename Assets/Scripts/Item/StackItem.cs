using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StackItem
{
    public Item item;
    public int stackCount = 1;
    public int maxStack;
    public ItemQualityType quality = ItemQualityType.Common;

    private bool isCollectable = false;
    private bool isCollecting = false;
    public StackItem(Item item, int stackCount = 1, ItemQualityType quality = ItemQualityType.Common) {
        this.item = item;
        this.stackCount = stackCount;
        this.quality = quality;
    }

    public StackItem(StackItem oldItem)
    {
        if (oldItem == null) {
            return;
        }
        this.item = oldItem.item;
        this.stackCount = oldItem.stackCount;
        this.quality = oldItem.quality;
    }

    public StackItem() { }

    public bool IsCollectable()
    {
        return isCollectable;
    }

    public void EnableCollect() {
        this.isCollectable = true;
    }

    public void StartCollecting() {
        isCollecting = true;
    }

    public bool IsCollecting()
    {
        return isCollecting;
    }

    public bool IsSame(StackItem other)
    {
        return OtherNotNull(other) && item.itemName == other.item.itemName && quality == other.quality;
    }
     
    public bool IsSameOrAbove(StackItem other)
    {
        return OtherNotNull(other) && item.itemName == other.item.itemName
            && ItemUtils.Instance.IsSameQualityOrAbove(quality, other.quality);
    }

    public bool IsSameIgnoreQuality(StackItem other)
    {
        return OtherNotNull(other) && item.itemName == other.item.itemName;
    }

    private bool OtherNotNull(StackItem other) {
        return item != null && other != null && other.item != null;
    }
}
