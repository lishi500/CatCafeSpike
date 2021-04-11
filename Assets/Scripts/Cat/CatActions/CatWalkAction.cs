using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWalkAction : CatAction
{
    public override bool ApproachingInteractionPostion() {
        return false;
    }

    protected override void Action() {
        if (cat != null) {
            StartCoroutine(WalkToPos());
        }
    }

    IEnumerator WalkToPos() {
        Vector3 starPos = cat.transform.position;
        Vector3 endPos = targetPosition;
        float distance = Vector3.Distance(starPos, endPos);
        float etc = distance / cat.attriburte.walkSpeed;
        bool reachTarget = false;
        float elapsedTime = 0f;

        while (!reachTarget) {
            if (Vector3.Distance(cat.transform.position, endPos) < 0.01f) {
                reachTarget = true;
                OnActionFinished();
            }

            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp(elapsedTime / etc, 0f, 1f);
            t = CommonUtil.Instance.Smoothstep(t);

            cat.transform.position = Vector3.Lerp(starPos, endPos, t);
            yield return null;
        }
    }
}
