using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable", order = 2)]
public class Consumable : ScriptableObject
{
    public float provideNutrition;
    public float provideFood;
    public float provideWater;
    public bool IsConsumble;
    //public ConsumeType consumeType;
    //public List<Buff> onConsumeBuffs;
}
