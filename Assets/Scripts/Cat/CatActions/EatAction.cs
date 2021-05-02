using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatAction : Action {

    public override void StartAction() {
        Cat cat = GetCat();

        FurnitureBase foodBow = catCafe.GetFurnitureByType(FurnitureType.Food);
        InteractPoint point = foodBow.ReserveInteractionPoint(cat);
        if (point == null) {
            ActionEnd();
            return;
        }
        // TODO if no point
        CatWalkTask walkTask = actionHolder.AddComponent<CatWalkTask>();
        walkTask.SetTaskTarget(foodBow.gameObject, point.transform.position, cat);

        CatEatTask eatTask = actionHolder.AddComponent<CatEatTask>();
        eatTask.SetTaskTarget(foodBow.gameObject, Vector3.zero, cat);

        TaskChain chain = actionHolder.AddComponent<TaskChain>();
        chain.PushTask(walkTask);
        chain.PushTask(eatTask);
        chain.notifyTaskChainEnd += OnTaskChainEnd;

        chain.StartTaskChain();
    }

    public void OnTaskChainEnd(TaskChain taskChain) {
        ActionEnd();
    }

    public override void Interrupt() {
        throw new System.NotImplementedException();
    }
}
