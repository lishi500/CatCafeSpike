using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBow : FurnitureBase {
    public int currentFood;
    public int maxFood;

    public override bool CanCatInteract(Cat cat) {
        if (currentFood > 0) {
            foreach (InteractPoint interactPoint in interactPoints) {
                if (interactPoint.reserveCat == cat) {
                    return true;
                }
            }
        }

        return false;
    }

    public override bool CanCustomerInteract(Customer customer) {
        return false;
    }


    public override void CatInteraction(Cat cat) {
        if (CanCatInteract(cat)) {
            currentFood -= 1;
            UpdateFoodCount();
        }
    }

    public override void CustomerInteraction(Customer customer) {

    }

    protected override void OnUserClick() {
        int needToFill = maxFood - currentFood;
        int withdraw = Storage.Instance.WithdrawCatFood(needToFill);
        currentFood += withdraw;
        UpdateFoodCount();
    }

    private void UpdateFoodCount() { 
        TextUtil.Instance.SetFollowText(gameObject, currentFood + "/" + maxFood);
    }

    private void Start() {
        UpdateFoodCount();
    }
}
