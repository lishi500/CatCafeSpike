using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkBow : FurnitureBase
{
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
        if (CanCatInteract(cat)) { 
        
        }
    }

    public override void CustomerInteraction(Customer customer) {
    }

    protected override void OnUserClick() {
    }

    public override void Awake() {
        base.Awake();
        canClick = false;
    }
}
