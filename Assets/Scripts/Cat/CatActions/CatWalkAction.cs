using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWalkAction : CatAction
{
  
    public override bool CanStartAction() {
        return true;
    }

    protected override void Action() {
        if (cat != null) {
            StartCoroutine(WalkToPos());
        }
    }

    protected override void ActionAnimation() {
        TextUtil.Instance.SetFollowText(cat.gameObject, "Walk");
    }

    protected override void ActionEnd() {
        TextUtil.Instance.SetFollowText(cat.gameObject, cat.name);
    }

    IEnumerator WalkToPos() {
        Vector3 starPos = cat.transform.position;
        Vector3 endPos = targetPosition;
        float distance = Vector3.Distance(starPos, endPos);
        float etc = distance / cat.attriburte.walkSpeed;
        bool reachTarget = false;
        float elapsedTime = 0f;
        ActionAnimation();

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
