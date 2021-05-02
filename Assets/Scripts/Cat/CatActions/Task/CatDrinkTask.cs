using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDrinkTask : CatTask
{
    DrinkBow drinkBow;

    public override void SetTaskTarget(GameObject obj, Vector3 tar, Cat cat) {
        interactionObject = obj;
        targetPosition = tar;
        this.cat = cat;
        drinkBow = obj.GetComponent<DrinkBow>();
    }

    public override bool PreTaskCheck() {
        foreach (InteractPoint interactPoint in drinkBow.interactPoints) {
            if (Vector3.Distance(interactPoint.transform.position, cat.transform.position) < 0.1f) {
                return true;
            }
        }

        return false;
    }

    protected override void TaskAnimation() {
        TextUtil.Instance.SetFollowText(cat.gameObject, "Drink...");
    }

    protected override void TaskEnd() {
        TextUtil.Instance.SetFollowText(cat.gameObject, cat.name);
    }

    protected override IEnumerator TaskStart() {
        if (drinkBow.CanCatInteract(cat)) {
            TaskAnimation();
            drinkBow.CatInteraction(cat);
            yield return StartCoroutine(DrinkTask());
        }
    }

    private IEnumerator DrinkTask() {
        yield return new WaitForSeconds(4f);
        OnTaskFinished();
    }

    private void Awake() {
    }
}
