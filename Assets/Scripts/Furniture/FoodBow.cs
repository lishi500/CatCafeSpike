using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBow : CatFurniture {
    public int currentFood;
    public int maxFood;

    public override bool CanCatInteract(Cat cat) {
        if (currentFood > 0 && HasCatReservered(cat) && CanOccupy(cat)) {
            return true;
        }
        return false;
    }
    public override void CatInteraction(Cat cat) {
        currentFood -= 1;
        UpdateFoodCount();
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
