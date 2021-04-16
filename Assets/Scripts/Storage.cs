using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Singleton<Storage>
{
    public int money;
    public int catFood;
    public int catCan;
    public int heart;

    public int WithdrawCatFood(int amount) {
        if (amount <= catFood) {
            catFood -= amount;
            return amount;
        } else {
            catFood = 0;
            return catFood;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
