using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlayBallTask : CatTask
{
    Ball ball;
    public override void SetTaskTarget(GameObject obj, Vector3 tar, Cat cat) {
        interactionObject = obj;
        targetPosition = tar;
        this.cat = cat;
        ball = obj.GetComponent<Ball>();
    }

    public override bool PreTaskCheck() {
        return true;
    }
    protected override void TaskAnimation() {
        TextAnimation("Play ball");
    }

    protected override void TaskEnd() {
        TextAnimation(cat.name);
    }

    protected override IEnumerator TaskStart() {
        float pushPower = Random.Range(0.5f, 3f);
        ball.PlayBy(cat, pushPower);

        yield return new WaitForSeconds(0.5f);
        OnTaskFinished();
    }

}
