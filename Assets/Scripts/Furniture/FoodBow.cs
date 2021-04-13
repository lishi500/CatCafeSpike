using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBow : FurnitureBase {
    public int currentFood;
    public int maxFood;

    public override bool CanCatInteract(Cat cat) {
        foreach (InteractPoint interactPoint in interactPoints) {
            if (interactPoint.reserveCat == cat) {
                return true;
            }
        }

        return false;
    }

    public override bool CanCustomerInteract(Customer customer) {
        return false;
    }


    public override void CatInteraction(Cat cat) {
        
    }

    public override void CustomerInteraction(Customer customer) {
    }

    protected override void OnUserClick() {

    }

    private void UpdateFoodCount() { 
        TextUtil.Instance.SetFollowText(gameObject, currentFood + "/" + maxFood);
    }

    private void Start() {
        UpdateFoodCount();
    }
}
