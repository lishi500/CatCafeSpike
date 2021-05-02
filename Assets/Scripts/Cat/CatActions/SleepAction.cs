using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAction : Action {
    public override void Interrupt() {
        throw new System.NotImplementedException();
    }

    public override void StartAction() {
        CatSleepTask sleepTask = ActionUtils.Instance.CreatCatTaskByType(TaskType.Sleep, null, Vector3.zero, GetCat()) as CatSleepTask;
        sleepTask.StartTask();

        sleepTask.notifyTaskEnd += OnTaskEnd;
    }

    public void OnTaskEnd(Task task) {
        ActionEnd();
    }
}
