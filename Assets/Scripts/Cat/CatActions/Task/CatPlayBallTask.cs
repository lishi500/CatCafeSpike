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
        Ball ball = interactionObject.GetComponent<Ball>();
    }

    public override bool PreTaskCheck() {
        return true;
    }
    protected override void TaskAnimation() {
        throw new System.NotImplementedException();
    }

    protected override void TaskEnd() {
        throw new System.NotImplementedException();
    }

    protected override IEnumerator TaskStart() {
        throw new System.NotImplementedException();
    }

   
}
