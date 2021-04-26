using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkAction : Action
{
    public override void StartAction() {
        Cat cat = GetCat();

        FurnitureBase drinkBow = catCafe.GetFurnitureByType(FurnitureType.Water);
        InteractPoint point = drinkBow.ReserveInteractionPoint(cat);

        CatWalkTask walkTask = actionHolder.AddComponent<CatWalkTask>();
        walkTask.SetTaskTarget(null, point.transform.position, cat);

        CatDrinkTask drinkTask = actionHolder.AddComponent<CatDrinkTask>();
        drinkTask.SetTaskTarget(drinkBow.gameObject, Vector3.zero, cat);

        TaskChain chain = actionHolder.AddComponent<TaskChain>();
        chain.PushTask(walkTask);
        chain.PushTask(drinkTask);
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
