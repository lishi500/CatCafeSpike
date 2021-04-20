using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Body
{
    public Attribute hunger;
    public Attribute thirst;
    // play with human/ play with toy/ play with cat(maybe)/eat/drink/sleep increase mood;
    // hunger/thirst/energy level decrease mood
    public Attribute mood;
    // sleep/eat/drink increase energy. daily activity, play consume energy
    public Attribute energy;
    public Attribute tiredness;


    // sick
    public void Eat() {
        hunger.SetValue(hunger.maxValue);
    }

    public void Drink() {
        thirst.SetValue(thirst.maxValue);
    }

    public List<Attribute> GetAllAttributes() { 
        return new List<Attribute>{ hunger, thirst, mood, energy, tiredness };
    }
}
