using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskChain : MonoBehaviour {
    Queue<Task> taskQueue;
    Task currentTask;
    public float retryTimeInterval = 0.5f;
    public float waitTimeIntervalBetweenTasks = 0.3f;
    public int taskMaxRetryTime = 3;
    public bool canRetry = true;
    private bool isExecuting = false;
    private bool isStarted = false;

    public delegate void TaskChainEndEvent(TaskChain taskChain);
    public event TaskChainEndEvent notifyTaskChainEnd;
    public void PushTask(Task task) {
        taskQueue.Enqueue(task);
    }

    public bool IsAllTaskCompleted() {
        return taskQueue.Count == 0;
    }

    public void StartTaskChain() {
        isStarted = true;
    }

    private void ExecuteNextTask() {
        if (CanExecuteNextTask()) {
            MoveToNextTask();
            currentTask.notifyTaskEnd += ListenTaskEnd;
            ExecuteCurrentTask();
        }
    }

    //private IEnumerator RetryCurrentTask() {
    //    taskMaxRetryTime--;
    //    yield return new WaitForSeconds(retryTimeInterval);
    //    ExecuteNextTask();
    //}
    private void ExecuteCurrentTask() {
        isExecuting = true;
        Debug.Log("Executing task " + currentTask.taskName);
        currentTask.StartTask();
    }

    private void ListenTaskEnd(Task task) {
        if (task == currentTask) {
            currentTask.notifyTaskEnd -= ListenTaskEnd;
            StartCoroutine(WaitAndStartNextTask());
        }
    }
   

    private bool CanExecuteNextTask() {
        Task nextTask = taskQueue.Peek();
        if (nextTask != null) {
            return nextTask.PreTaskCheck();
        }
        return false;
    }

    private void MoveToNextTask() {
        Task nextTask = taskQueue.Dequeue();
        Debug.Log("Move to next Task -> " + nextTask.taskName);
        currentTask = nextTask;
    }
    private IEnumerator WaitAndStartNextTask() {
        yield return new WaitForSeconds(waitTimeIntervalBetweenTasks);
        isExecuting = false;
    }


    private void Awake() {
        taskQueue = new Queue<Task>();
    }

    private void Update() {
        if (isStarted && !isExecuting) {
            if (IsAllTaskCompleted()) {
                if (notifyTaskChainEnd != null) {
                    notifyTaskChainEnd(this);
                }
                Destroy(this);
            } else { 
                ExecuteNextTask();
            }
        }
    }
}