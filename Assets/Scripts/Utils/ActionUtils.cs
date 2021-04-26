using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionUtils : Singleton<ActionUtils>
{
    public CatTask CreatCatTaskByType(TaskType taskType, GameObject obj, Vector3 tar, Cat cat) {
        GameObject holder = GameManager.Instance.actionHolder;
        CatTask task;
        switch (taskType) {
            case TaskType.Idle:
                task = new CatIdleTask();
                break;
            case TaskType.Drink:
                task = new CatDrinkTask();
                break;
            case TaskType.Eat:
                task = new CatEatTask();
                break;
            case TaskType.LickHair:
                task = new CatLickHairTask();
                break;
            case TaskType.Miao:
                task = new CatMiaoTask();
                break;
            case TaskType.PlayBall:
                task = new CatPlayBallTask();
                break;
            case TaskType.PlayWithCat:
                task = new CatPlaywithCatTask();
                break;
            case TaskType.SelfPlay:
                task = new CatSelfPlayTask();
                break;
            case TaskType.Sleep:
                task = new CatSleepTask();
                break;
            case TaskType.Tickle:
                task = new CatTickleTask();
                break;
            case TaskType.Walk:
                task = new CatWalkTask();
                break;
            default:
                task = new CatIdleTask();
                break;
        }
        task.SetTaskTarget(obj, tar, cat);
        return task;
    }


}
