using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEatTask : CatTask
{
    FoodBow foodBow;
    float eatTime = 4;

    public override void SetTaskTarget(GameObject obj, Vector3 tar, Cat cat) {
        interactionObject = obj;
        targetPosition = tar;
        this.cat = cat;
        foodBow = obj.GetComponent<FoodBow>();
    }

    public override bool PreTaskCheck() {
        foreach (InteractPoint interactPoint in foodBow.interactPoints) {
            if (Vector3.Distance(interactPoint.transform.position, cat.transform.position) < 0.1f) {
                return true;
            }
        }
        Debug.Log("Eat Task pre check failed ");
        return false;
    }

    protected override IEnumerator TaskStart() {
        if (foodBow.CanCatInteract(cat)) {
            foodBow.PreCatInteraction(cat);
            yield return StartCoroutine(EatTask());
        }
    }

    IEnumerator EatTask() {
        TaskAnimation();
        foodBow.CatInteraction(cat);
        yield return new WaitForSeconds(eatTime);
        OnTaskFinished();
    }

    protected override void TaskAnimation() {
        TextUtil.Instance.SetFollowText(cat.gameObject, "Eat...");
    }

    protected override void TaskEnd() {
        foodBow.InteractionEnd(cat);
        TextUtil.Instance.SetFollowText(cat.gameObject, cat.name);
    }

    void Awake() {
        taskName = "Cat Eat Task";
    }
}
