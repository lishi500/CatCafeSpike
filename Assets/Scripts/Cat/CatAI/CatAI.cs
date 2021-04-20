using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAI : MonoBehaviour
{
    Cat cat;
    CatAIState currentAIState;
    Dictionary<Attribute, AICondition> attributeMapping;

    AICondition SelectNextStateByAttribute() {
        List<Attribute> keyList = new List<Attribute>(attributeMapping.Keys);
        Attribute winAttribute = AIUtils.Instance.AttrChanceCalc(keyList);
        AICondition condition = attributeMapping[winAttribute];
        return condition;
    }

    void MapAttribute() {
        attributeMapping.Add(cat.body.hunger, AICondition.HUNGRY);
        attributeMapping.Add(cat.body.thirst, AICondition.THIRSTY);
        attributeMapping.Add(cat.body.energy, AICondition.ENERGY);
        attributeMapping.Add(cat.body.mood, AICondition.MOOD);
        attributeMapping.Add(cat.body.tiredness, AICondition.TIREDNESS);
    }
    // Start is called before the first frame update
    void Start()
    {
        MapAttribute();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
