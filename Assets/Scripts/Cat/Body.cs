using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Body
{
    public float hunger;
    public float thirst;
    public float mood;

    public float hungerMax;
    public float thirstMax = 100;
    public float moodMax = 100;

    // sick
    public void Eat() {
        hunger = hungerMax;
    }

    public void Drink() {
        thirst = thirstMax;
    }
}
