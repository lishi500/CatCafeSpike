using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public ItemType type;
    public string description;
    public int basePrice;

    public int level = 1;
    public bool playerProducable = true;

    public Consumable consumable;

    public GameObject itemPrafab;
    public Sprite icon;
    // havestable, chest box

    public bool IsSame(Item other)
    {
        return other != null && itemName == other.itemName;
    }

}
