using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWalkTask : CatTask
{
    public float StopDistance = 0;
    public override bool PreTaskCheck() {
        return true;
    }

    protected override IEnumerator TaskStart() {
        if (cat != null) {
           yield return StartCoroutine(WalkToPos());
        }
    }

    protected override void TaskAnimation() {
        TextUtil.Instance.SetFollowText(cat.gameObject, "Walk " + (interactionObject != null ? " towards " + interactionObject.name : ""));
    }

    protected override void TaskEnd() {
        TextUtil.Instance.SetFollowText(cat.gameObject, cat.name);
    }

    IEnumerator WalkToPos() {
        Vector3 starPos = cat.transform.position;
        Vector3 endPos = TransformUtils.Instance.PositionWithStopDistance(starPos, targetPosition, StopDistance); 
        float distance = Vector3.Distance(starPos, endPos);
        float etc = distance / cat.attriburte.walkSpeed;
        bool reachTarget = false;
        float elapsedTime = 0f;
        TaskAnimation();

        while (!reachTarget) {
            if (Vector3.Distance(cat.transform.position, endPos) < 0.01f) {
                reachTarget = true;
                OnTaskFinished();
            }

            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp(elapsedTime / etc, 0f, 1f);
            t = CommonUtil.Instance.Smoothstep(t);

            cat.transform.position = Vector3.Lerp(starPos, endPos, t);
            yield return null;
        }
    }

    void Awake() {
        taskName = "Cat Walk Task";
    }
}
