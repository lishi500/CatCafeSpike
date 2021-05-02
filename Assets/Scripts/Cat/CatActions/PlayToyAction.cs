using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayToyAction : Action
{
    TaskType[] toyTypes = new TaskType[] { TaskType.PlayBall };
    CatTask toyTask;
    GameObject toyObj;

    public void SetToyTask(CatTask task) {
        this.toyTask = task;
    }

    public void SelectNearestToy() { 
        GameObject[] toys = GameObject.FindGameObjectsWithTag("Toy");
        GameObject nearstToy = TransformUtils.Instance.SelectNearestObj(self, toys);
        toyObj = nearstToy;
    }
   

    public override void StartAction() {
        if (toyTask == null) {
            SelectNearestToy();
            // TODO more toys
            toyTask = ActionUtils.Instance.CreatCatTaskByType(TaskType.PlayBall, toyObj, Vector3.zero, GetCat());
        }

        if (toyObj == null) {
            Debug.LogError("Cannot find any Toy");
            return;
        }
        CatRunTask runTask = ActionUtils.Instance.CreatCatTaskByType(TaskType.Run, toyObj, toyObj.transform.position, GetCat()) as CatRunTask;
        runTask.StopDistance = 0.5f;

        CatPlayBallTask playBallTask = actionHolder.AddComponent<CatPlayBallTask>();
        playBallTask.SetTaskTarget(toyObj, Vector3.zero, GetCat());

        TaskChain chain = actionHolder.AddComponent<TaskChain>();
        chain.PushTask(runTask);
        chain.PushTask(playBallTask);
        chain.notifyTaskChainEnd += OnTaskChainEnd;

        chain.StartTaskChain();
    }

    public void OnTaskChainEnd(TaskChain taskChain) {
        ActionEnd();
    }

    public override void Interrupt() {

    }
}
