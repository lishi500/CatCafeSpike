using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAction : Action {
    public override void Interrupt() {
        throw new System.NotImplementedException();
    }

    public override void StartAction() {
        CatTask sleepTask = ActionUtils.Instance.CreatCatTaskByType(TaskType.Sleep, null, Vector3.zero, GetCat());
        sleepTask.StartTask();
    }
}
