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
        CatWalkAction walkAction = actionHolder.AddComponent<CatWalkAction>();
        FurnitureBase foodBow = catCafe.GetFurnitureByType(FurnitureType.Food);
        InteractPoint point = foodBow.GetAvaiableInteractionPoint();
        point.Reserve(testCat);
        walkAction.SetActionTarget(null, point.transform.position, testCat);
        walkAction.StartAction();
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
