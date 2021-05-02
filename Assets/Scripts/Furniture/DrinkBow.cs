using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkBow : CatFurniture {
    public override bool CanCatInteract(Cat cat) {
        return HasCatReservered(cat) && CanOccupy(cat);
    }
  
    public override void CatInteraction(Cat cat) {
        if (CanCatInteract(cat)) {
            cat.body.Drink();
        }
    }


    protected override void OnUserClick() {
    }

    public override void Awake() {
        base.Awake();
        canClick = false;
    }

}
