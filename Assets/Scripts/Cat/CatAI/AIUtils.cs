using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class AIUtils : Singleton<AIUtils>
{
    public AttributeType AttrChanceCalc(List<AICondition> conditions) {
        float totalChance = conditions.Select(cond => cond.weightedChange).ToArray().Sum();
        float rndNumber = Random.Range(0, totalChance);
        float sumChange = 0;
        for (int i = 0; i < conditions.Count(); i++) {
            sumChange += conditions[i].weightedChange;
            if (rndNumber <= sumChange) {
                return conditions[i].type;
            }
        }
        return AttributeType.NONE;
    }

    public List<AICondition> ConvertToAIConditionsFromAttributes(List<Attribute> attributes) {
        return attributes.Select(attr => AICondition.FromAttribute(attr)).ToList<AICondition>();
    }

    public List<Cat> FindCatInRange(Vector3 center, float range) {
        GameObject[] catObjs = TransformUtils.Instance.GetObjectWithInRadiusByTags(center, range, new string[] { "Cat" });
        return catObjs.Select(obj => obj.GetComponent<Cat>()).ToList();
    }

    public List<CatToy> FindCatToyInRange(Vector3 center, float range) {
        GameObject[] catToyObjs = TransformUtils.Instance.GetObjectWithInRadiusByTags(center, range, new string[] { "Toy" });
        return catToyObjs.Select(obj => obj.GetComponent<CatToy>()).ToList();
    }

    public List<Customer> FindCustomerInRange(Vector3 center, float range) {
        GameObject[] customerObjs = TransformUtils.Instance.GetObjectWithInRadiusByTags(center, range, new string[] { "Customer" });
        return customerObjs.Select(obj => obj.GetComponent<Customer>()).ToList();
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

    public float WeightedMissingValue(Attribute attr) {
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
