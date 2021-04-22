using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAI : MonoBehaviour
{
    Cat cat;
    CatAIState currentAIState;
    private List<Attribute> m_bodyAttributes;
    protected List<Attribute> BodyAttributes {
        get { if (m_bodyAttributes == null) { m_bodyAttributes = cat.body.GetAllBodyAttributes(); } return m_bodyAttributes; }
        set { m_bodyAttributes = value; }
    }
    AICondition idleCondition;


    AttributeType SelectNextAttribute() {
        List<AICondition> bodyConditions = AIUtils.Instance.ConvertToAIConditionsFromAttributes(BodyAttributes);
        bodyConditions.Add(idleCondition);
        AttributeType winAttribute = AIUtils.Instance.AttrChanceCalc(bodyConditions);

        return winAttribute;
    }

    CatAIState SelectNextAIState(AttributeType type) {
        switch (type) {
            case AttributeType.NONE:
                return CatAIState.Idle;
            case AttributeType.HUNGRY:
                return CatAIState.Eat;
            case AttributeType.THIRSTY:
                return CatAIState.Drink;
            case AttributeType.MOOD:
                return CatAIState.PlayWithCustomer;
            case AttributeType.TIREDNESS:
                return CatAIState.Sleep;
            case AttributeType.ENERGY:
                return CatAIState.PlayToy;
            default:
                return CatAIState.Idle;
        }
    }

    private void Awake() {
        idleCondition = new AICondition(AttributeType.NONE, 100);
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
