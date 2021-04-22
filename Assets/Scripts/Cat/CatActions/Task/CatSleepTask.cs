using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSleepTask : CatTask
{
    public float sleepTime;
    private float pastTime;
    private bool isGetInterrupt;
    private bool isStarted;

    public void InterruptSleep() {
        isGetInterrupt = true;
    }
    public override bool PreTaskCheck() {
        return true;
    }

    protected override void TaskAnimation() {
        TextUtil.Instance.SetFollowText(cat.gameObject, "Sleep...");
    }

    protected override void TaskEnd() {
        TextUtil.Instance.SetFollowText(cat.gameObject, cat.name);
    }

    protected override IEnumerator TaskStart() {
        isStarted = true;
        TaskAnimation();
        yield return null;
    }

    private void Update() {
        if (isStarted) {
            if (sleepTime > pastTime && !isGetInterrupt) {
                pastTime += Time.deltaTime;
            } else {
                OnTaskFinished();
            }
        }
    }
}
