using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICondition
{
    public AttributeType type;
    public float weightedChange;
    public AICondition(AttributeType type, float weightedChange) {
        this.type = type;
        this.weightedChange = weightedChange;
    }

    public static AICondition FromAttribute(Attribute attribute) {
        return new AICondition(attribute.type, AIUtils.Instance.WeightedMissingValue(attribute));
    }
}
