using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLickHairTask : CatTask
{
    public override bool PreTaskCheck() {
        return true;
    }

    protected override void TaskAnimation() {
        TextAnimation("licking..."); 
    }

    protected override void TaskEnd() {
        TextAnimation(cat.name);
    }

    protected override IEnumerator TaskStart() {
        TaskAnimation();
        yield return new WaitForSeconds(TaskTimeDef.LickingTime);
        OnTaskFinished();
    }

}
