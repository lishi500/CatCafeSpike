using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAI : MonoBehaviour
{
    Cat cat;
    CatAIState currentAIState;
    Action currentAction;
    private List<Attribute> m_bodyAttributes;
    public bool isAIEnabled = true;
    public bool isProcessing = false;

    protected List<Attribute> BodyAttributes {
        get { if (m_bodyAttributes == null) { 
                m_bodyAttributes = cat.body.GetAllBodyAttributes(); 
            } 
            return m_bodyAttributes; 
        }
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
            case AttributeType.MOOD: // TODO add after finish Customer
                //return CatAIState.PlayWithCustomer;
                return CatAIState.Sleep;
            case AttributeType.TIREDNESS:
                return CatAIState.Sleep;
            case AttributeType.ENERGY:
                return CatAIState.PlayToy;
            default:
                return CatAIState.Idle;
        }
    }

    public void NextAction(CatAIState state) {
        currentAIState = state;
        isProcessing = true;
        switch (state) {
            case CatAIState.Idle:
                StartNoneTargetAction(typeof(IdleAction));
                break;
            case CatAIState.Eat:
                StartNoneTargetAction(typeof(EatAction));
                break;
            case CatAIState.Drink:
                StartNoneTargetAction(typeof(DrinkAction));
                break;
            case CatAIState.PlayWithCustomer:
                break;
            case CatAIState.Sleep:
                StartNoneTargetAction(typeof(SleepAction));
                break;
            case CatAIState.PlayToy:
                break;
            default:
                break;
        }
        currentAction.notifyActionEnd += OnActionEnd;
    }

    private void StartNoneTargetAction(System.Type type) {
        currentAction = cat.gameObject.AddComponent(type) as Action;
        currentAction.Init(cat.gameObject, null);
        currentAction.StartAction();
    }

    private void OnActionEnd(Action action) {
        Debug.Log("OnActionEnd " + action.name );
        currentAIState = CatAIState.None;
        isProcessing = false;
    }

    private void Awake() {
        cat = GetComponent<Cat>();
        if (cat == null) {
            isAIEnabled = false;
            Debug.LogError("Cat is null, Cat AI disabled");
        }
        idleCondition = new AICondition(AttributeType.NONE, 100);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isAIEnabled && !isProcessing) {
            AttributeType attributeType = SelectNextAttribute();
            Debug.Log("Next Attribute " + attributeType);
            CatAIState catAIState = SelectNextAIState(attributeType);
            Debug.Log("Next AI state " + catAIState);

            NextAction(catAIState);
        }
    }
}
