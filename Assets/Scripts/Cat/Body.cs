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

    public Attribute hungryConsumptionRate;
    public Attribute thirstConsumptionRate;
    public Attribute energyConsumptionRate;
    public Attribute moodConsumptionRate;
    public Attribute tirednessConsumptionRate;

    // sick
    public void Eat() {
        hunger.AddValue(25);
    }

    public void Drink() {
        thirst.SetValue(50);
    }

    public void ConsumeBodyAttribute(Attribute attr, Attribute attrConsumetionRate, bool isInverse = false) {
        float consumeAmount = attrConsumetionRate.GetProcessedValue() * (isInverse ? -1 : 1);
        attr.SubValue(consumeAmount);
    }

    public List<Attribute> GetAllBodyAttributes() { 
        return new List<Attribute>{ hunger, thirst, mood, energy, tiredness };
    }
}
