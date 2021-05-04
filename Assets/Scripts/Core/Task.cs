using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : MonoBehaviour
{
    public GameObject interactionObject;
    public Vector3 targetPosition;
    public string taskName;
    public bool canInterrupt;
    private bool isInterrupted;
    private Coroutine currentCoroutine;

    public delegate void TaskStartEvent(Task task);
    public event TaskStartEvent notifyTaskStart;
    public delegate void TaskEndEvent(Task task);
    public event TaskEndEvent notifyTaskEnd;
    public delegate void TaskInterruptEvent(Task task);
    public event TaskInterruptEvent notifyTaskInterrupt;

    public virtual void StartTask() {
        if (PreTaskCheck()) {
            OnTaskStarted();
            currentCoroutine = StartCoroutine(TaskStart());
        }
    }

    public void Interrupt() {
        isInterrupted = true;
        if (notifyTaskInterrupt != null) {
            notifyTaskInterrupt(this);
        }
        if (currentCoroutine != null) { 
            StopCoroutine(currentCoroutine);
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
        //Debug.Log(taskName + " Finished");
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
