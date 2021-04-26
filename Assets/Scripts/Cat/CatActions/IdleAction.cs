using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : Action
{
    CatTask idleTask;
    TaskType[] idleTypes = new TaskType[] { TaskType.Idle, TaskType.Miao, TaskType.Tickle, TaskType.LickHair };
    public void SetIdleTask(CatTask task) {
        this.idleTask = task;
    }

    void RandomSelectIdelTask() {
        TaskType rndType = idleTypes[Random.Range(0, idleTypes.Length - 1)];
        switch (rndType) {
            case TaskType.Idle:
                idleTask = ActionUtils.Instance.CreatCatTaskByType(TaskType.Idle, null, Vector3.zero, GetCat());
                break;
            case TaskType.Miao:
                idleTask = ActionUtils.Instance.CreatCatTaskByType(TaskType.Miao, null, Vector3.zero, GetCat());
                break;
            case TaskType.Tickle:
                idleTask = ActionUtils.Instance.CreatCatTaskByType(TaskType.Tickle, null, Vector3.zero, GetCat());
                break;
            case TaskType.LickHair:
                idleTask = ActionUtils.Instance.CreatCatTaskByType(TaskType.LickHair, null, Vector3.zero, GetCat());
                break;
            default:
                idleTask = ActionUtils.Instance.CreatCatTaskByType(TaskType.Idle, null, Vector3.zero, GetCat());
                break;
        }
    }


    public override void StartAction() {
        if (idleTask == null) {
            RandomSelectIdelTask();
        }
        idleTask.StartTask();
    }

    public override void Interrupt() {
        throw new System.NotImplementedException();
    }
}
