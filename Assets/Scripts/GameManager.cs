using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Cat testCat;
    public FurnitureBase targetFurniture;
    public GameObject actionHolder;
    public CatCafe catCafe;
    
    // Start is called before the first frame update
    void Start()
    {
        catCafe = GetComponent<CatCafe>();
    }

    private void TestFunction() {
        FurnitureBase foodBow = catCafe.GetFurnitureByType(FurnitureType.Food);
        InteractPoint point = foodBow.ReserveInteractionPoint(testCat);

        CatWalkTask walkTask = actionHolder.AddComponent<CatWalkTask>();
        walkTask.SetTaskTarget(null, point.transform.position, testCat);

        CatEatTask eatTask = actionHolder.AddComponent<CatEatTask>();
        eatTask.SetTaskTarget(foodBow.gameObject, Vector3.zero, testCat);

        TaskChain chain = actionHolder.AddComponent<TaskChain>();
        chain.PushTask(walkTask);
        chain.PushTask(eatTask);

        chain.StartTaskChain();
    }

    int delayAction = 5;
    float delayTimer = 0;
    bool isDelayActionTriggered = false;
    void Update() {
        delayTimer += Time.deltaTime;
        if (delayTimer >= delayAction && !isDelayActionTriggered) {
            isDelayActionTriggered = true;
            TestFunction();
        }
    }
}
