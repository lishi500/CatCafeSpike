using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Cat testCat;
    public FurnitureBase targetFurniture;
    public GameObject actionHolder;
    public CatCafe catCafe;
    public Ball ball;

    protected override void Awake() {
        base.Awake();
        catCafe = GetComponent<CatCafe>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void TestFunction() {
       
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
