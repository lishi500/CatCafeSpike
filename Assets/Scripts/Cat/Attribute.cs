using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Attribute
{
    public AttributeType type;
    [SerializeField]
    private float m_value;
    public float value {
        get { return value; }
        set { SetValue(value); }
    }
    public float maxValue = 100;
    [HideInInspector]
    public float minValue = 0;
    [HideInInspector]
    public float adder = 0;
    [HideInInspector]
    public float modifier = 1;

    [SerializeField]
    private float m_weight = 1;
    public float weight {
        get { return (weight + weightAdder) * weightModifier; }
        set { m_weight = value; }
    }
    [HideInInspector]
    public float weightAdder = 0;
    [HideInInspector]
    public float weightModifier = 1;

    public bool isInverseCalc = false;


    public void SetValue(float v) {
        m_value = Mathf.Clamp(v, minValue, maxValue);
    }

    public void AddValue(float add) {
        float newValue = m_value + add;
        SetValue(newValue);
    }

    public void SubValue(float sub) {
        float newValue = m_value - sub;
        SetValue(newValue);
    }

    public float GetProcessedValue() {
        return (value + adder) * modifier;
    }

    public float GetWeightedProcessedValue() {
        return weight * GetProcessedValue();
    }
}
