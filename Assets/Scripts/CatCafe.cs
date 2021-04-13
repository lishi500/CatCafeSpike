using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCafe : MonoBehaviour
{
    public CafeFurnitures furnitures;

    public FurnitureBase GetFurnitureByType(FurnitureType type) {
        switch (type) {
            case FurnitureType.Food:
                return furnitures.foodBow;
            default:
                return furnitures.foodBow;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
