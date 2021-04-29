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
        GameObject[] toys = GameObject.FindGameObjectsWithTag(tag);
        GameObject nearstToy = TransformUtils.Instance.SelectNearestObj(self, toys);
        toyObj = nearstToy;
    }
   

    public override void StartAction() {
        if (toyTask == null) {
            SelectNearestToy();
            // TODO more toys
            toyTask = ActionUtils.Instance.CreatCatTaskByType(TaskType.PlayBall, toyObj, Vector3.zero, GetCat());
        }
        CatWalkTask walkTask = actionHolder.AddComponent<CatWalkTask>();
        walkTask.SetTaskTarget(null, toyObj.transform.position, GetCat());
    }

    public override void Interrupt() {

    }
}
