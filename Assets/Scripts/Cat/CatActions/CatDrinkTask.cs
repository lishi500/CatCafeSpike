using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDrinkTask : CatTask
{
    DrinkBow drinkBow;
    public override bool PreTaskCheck() {
        throw new System.NotImplementedException();
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
        drinkBow = interactionObject.GetComponent<DrinkBow>();
    }
}
