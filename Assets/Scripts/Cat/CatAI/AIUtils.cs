using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class AIUtils : Singleton<AIUtils>
{
    public Attribute AttrChanceCalc(List<Attribute> attributes) {
        float[] chances = attributes.Select(attr => WeightedMissingValue(attr)).ToArray();
        float totalChance = chances.Sum();
        float rndNumber = Random.Range(0, totalChance);
        float sumChange = 0;
        for (int i = 0; i < chances.Count(); i++) {
            sumChange += chances[i];
            if (rndNumber <= sumChange) {
                return attributes[i];
            }
        }
        return null;
    }

    //public Attribute InverseAttr(Attribute attr) {
    //    Attribute attrNew = new Attribute();
    //    attrNew.maxValue = attr.maxValue;
    //    attrNew.minValue = attr.minValue;
    //    attrNew.weight = attr.weight;
    //    attrNew.adder = attr.adder;
    //    attrNew.modifier = attr.modifier;
    //    attrNew.weightAdder = attr.weightAdder;
    //    attrNew.weightModifier = attr.weightModifier;
    //    attrNew.value = attr.maxValue - attr.value;
    //    return attrNew;
    //}

    private float WeightedMissingValue(Attribute attr) {
        if (attr.isInverseCalc) { 
            return attr.value * attr.weight;
        }
        return (attr.maxValue - attr.value) * attr.weight;
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
