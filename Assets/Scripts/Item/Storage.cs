using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Singleton<Storage>
{
    public int money;
    public int catFood;
    public int catCan;
    public int heart;
    public List<StackItem> items;

    public int WithdrawCatFood(int amount) {
        if (amount <= catFood) {
            catFood -= amount;
            return amount;
        } else {
            catFood = 0;
            return catFood;
        }
    } 

    void LoadItems() { 
        items = new List<StackItem>();
    }
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
