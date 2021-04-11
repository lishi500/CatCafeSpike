using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CatAction : MonoBehaviour
{
    public GameObject interactionObject;
    public Vector3 targetPosition;
    public Cat cat;

    public delegate void CatActionStartEvent(CatAction action);
    public event CatActionStartEvent notifyCatActionStart;
    public delegate void CatActionEndEvent(CatAction action);
    public event CatActionEndEvent notifyCatActionEnd;

    public abstract bool ApproachingInteractionPostion();

    public void SetActionTarget(GameObject obj, Vector3 tar, Cat cat) {
        interactionObject = obj;
        targetPosition = tar;
        this.cat = cat;
    }

    public virtual void StartAction() {
        if (ApproachingInteractionPostion()) {
            OnActionStarted();
            Action();
        }
    }

    protected abstract void Action();

    public virtual void OnActionStarted() {
        if (notifyCatActionStart != null) {
            notifyCatActionStart(this);
        }
    }
    public virtual void OnActionFinished() {
        if (notifyCatActionEnd != null) {
            notifyCatActionEnd(this);
        }
    }

}
