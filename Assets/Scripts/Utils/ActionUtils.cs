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
                task = holder.AddComponent<CatIdleTask>();
                break;
            case TaskType.Drink:
                task = holder.AddComponent<CatDrinkTask>();
                break;
            case TaskType.Eat:
                task = holder.AddComponent<CatEatTask>();
                break;
            case TaskType.LickHair:
                task = holder.AddComponent<CatLickHairTask>();
                break;
            case TaskType.Miao:
                task = holder.AddComponent<CatMiaoTask>();
                break;
            case TaskType.PlayBall:
                task = holder.AddComponent<CatPlayBallTask>();
                break;
            case TaskType.PlayWithCat:
                task = holder.AddComponent<CatPlaywithCatTask>();
                break;
            case TaskType.SelfPlay:
                task = holder.AddComponent<CatSelfPlayTask>();
                break;
            case TaskType.Sleep:
                task = holder.AddComponent<CatSleepTask>();
                break;
            case TaskType.Tickle:
                task = holder.AddComponent<CatTickleTask>();
                break;
            case TaskType.Walk:
                task = holder.AddComponent<CatWalkTask>();
                break;
            case TaskType.Run:
                task = holder.AddComponent<CatRunTask>();
                break;
            default:
                task = holder.AddComponent<CatIdleTask>();
                break;
        }
        task.SetTaskTarget(obj, tar, cat);
        return task;
    }


}
