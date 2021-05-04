using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ItemUtils : Singleton<ItemUtils>
{
    public StackItem CloneItem(StackItem item, bool ignoreQuality = false) {
        if (item == null) {
            return item;
        }
        StackItem clonedItem = new StackItem(item.item, item.stackCount, item.quality);

        if (ignoreQuality) {
            clonedItem.quality = ItemQualityType.Common;
        }

        return clonedItem;
    }


    public T RandomInList<T>(List<T> items)
    {
        if (items != null && items.Count > 0) {
            int nextIndex = UnityEngine.Random.Range(0, items.Count - 1);
            return items[nextIndex];
        }
        return default(T);
    }

    public bool IsSameQualityOrAbove(ItemQualityType currentType, ItemQualityType targetType) {
        int typeDistance = QualityTypeDistance(currentType, targetType);
        return typeDistance >= 0;
    }

    public float GetStandardUpdateChance(ItemQualityType currentType, ItemQualityType targetType, float upgradeFactor = 1f) {
        int typeDistance = QualityTypeDistance(currentType, targetType);
        if (typeDistance > 0) {
            float standardChance = Mathf.Pow(0.1f, typeDistance);
            float factorChance = Mathf.Pow(upgradeFactor, typeDistance);
            return standardChance * factorChance;
        }

        return 0;
    }

    public ItemQualityType GetNextQualityTier(ItemQualityType currentType) {
        if (currentType == ItemQualityType.Artifact) {
            return ItemQualityType.Artifact;
        }

        int currentIndex = System.Array.IndexOf(qualityTypeMap, currentType);
        return qualityTypeMap[currentIndex + 1];
    }

    private ItemQualityType[] qualityTypeMap;
    public int QualityTypeDistance(ItemQualityType currentType, ItemQualityType targetType) {
        int currentIndex = System.Array.IndexOf(qualityTypeMap, currentType);
        int targetIndex = System.Array.IndexOf(qualityTypeMap, targetType);

        return targetIndex - currentIndex;
    }

    public StackItem MergeAddItem(List<StackItem> itemList, StackItem additem, bool createNewItem = false)
    {
        bool found = false;
        StackItem addedItem = additem;
        foreach (StackItem i in itemList)
        {
            if (i.IsSame(additem))
            {
                i.stackCount += additem.stackCount;
                addedItem = i;
                found = true;
                break;
            }
        }

        if (!found)
        {
            if (createNewItem)
            {
                StackItem newCreateItem = CloneItem(additem);
                addedItem = newCreateItem;

                itemList.Add(newCreateItem);
            }
            else {
                addedItem = additem;
                itemList.Add(additem);
            }
        }

        return addedItem;
    }

    public bool IsContainItem(List<StackItem> itemList, StackItem targetItem, bool ignoreQuality = true) {
        foreach (StackItem i in itemList)
        {
            if (ignoreQuality && i.IsSameIgnoreQuality(targetItem))
            {
                return true;
            }
            else if (!ignoreQuality && i.IsSame(targetItem)) {
                return true;
            }
        }

        return false;
    }

    public bool RemoveItemFromList(List<StackItem> itemList, StackItem targetItem) {
        StackItem foundItem = itemList.Find(item => item.IsSame(targetItem) && item.stackCount >= targetItem.stackCount);
        if (foundItem != null) {
            foundItem.stackCount = foundItem.stackCount - targetItem.stackCount;
            if (foundItem.stackCount == 0) {
                itemList.Remove(foundItem);
            }

            return true;
        }

        return false;
    }

    public List<StackItem> FindItem(List<StackItem> itemList, StackItem targetItem, int count, bool allowAbove = false) {
        if (targetItem == null || itemList == null || itemList.Count == 0) {
            return new List<StackItem>();
        }

        List<StackItem> founds = new List<StackItem>();
        if (allowAbove)
        {
            int leftNumber = count;
            StackItem foundSame = itemList.Find(item => item.IsSame(targetItem));
            if (foundSame.stackCount > count)
            {
                founds.Add(foundSame);
                return founds;
            }
            else
            {
                if (targetItem.quality != ItemQualityType.Artifact)
                {
                    founds.Add(foundSame);
                    leftNumber -= foundSame.stackCount;
                    StackItem nextItem = CloneItem(targetItem);
                    nextItem.quality = GetNextQualityTier(targetItem.quality);
                    founds.AddRange(FindItem(itemList, nextItem, leftNumber, allowAbove));
                }

                if (founds.Sum(item => item.stackCount) < count)
                {
                    founds.Clear();
                }
            }
        }
        else {
            founds.Add(itemList.Find(item => item.IsSame(item) && item.stackCount >= count));
        }

        founds.RemoveAll(item => item == null);
        return founds;
    }

    public Item LookUpItemPrafab(string itemName) {
        return Resources.Load<Item>("Data/Item/" + itemName);
    }

    protected override void Awake()
    {
        base.Awake();
        qualityTypeMap  = new ItemQualityType[] {
            ItemQualityType.Common, //白
            ItemQualityType.Good, // 绿
            ItemQualityType.Rare, // 蓝
            ItemQualityType.Epic, // 紫
            ItemQualityType.Legendary, // 橘
            ItemQualityType.Artifact // 红
        };
    }
}
