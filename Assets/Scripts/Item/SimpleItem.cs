using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SimpleItem", menuName = "Item/simple item", order = 1)]
public class SimpleItem : ScriptableObject
{
    public string itemName;
    public Sprite icon;
}
