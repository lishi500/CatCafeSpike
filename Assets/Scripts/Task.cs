using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : MonoBehaviour
{
    public GameObject interactionObject;
    public Vector3 targetPosition;
    public string taskName;

    public delegate void TaskStartEvent(Task task);
    public event TaskStartEvent notifyTaskStart;
    public delegate void TaskEndEvent(Task task);
    public event TaskEndEvent notifyTaskEnd;


    public virtual IEnumerator StartTask() {
        if (PreTaskCheck()) {
            OnTaskStarted();
            yield return TaskStart();
        }
    }

    public abstract bool PreTaskCheck();
    protected abstract IEnumerator TaskStart();
    protected abstract void TaskAnimation();
    protected abstract void TaskEnd();


    public virtual void OnTaskStarted() {
        if (notifyTaskStart != null) {
            notifyTaskStart(this);
        }
    }
    public virtual void OnTaskFinished() {
        Debug.Log(taskName + " Finished");
        if (notifyTaskEnd != null) {
            notifyTaskEnd(this);
        }
        TaskEnd();
        DestroyTask();
    }

    protected void DestroyTask() {
        Destroy(this);
    }

}
