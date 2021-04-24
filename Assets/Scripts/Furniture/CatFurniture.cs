using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CatFurniture : FurnitureBase
{
    public override void InteractionEnd(Cat cat) {
        InteractPoint point = GetOccupiedPoint(cat);
        point.ReleaseOccupy();
        NotifyEnd(cat);
    }
  
    public override void PreCatInteraction(Cat cat) {
        InteractPoint point = GetReservedPoint(cat);
        point.CatOccupy(cat);
    }

    public bool HasCatReservered(Cat cat) {
        return GetReservedPoint(cat) != null;
    }


    // ignore customer interaction
    public override bool CanCustomerInteract(Customer customer) {
        return false;
    }
    public override void CustomerInteraction(Customer customer) {
    }
    public override void InteractionEnd(Customer customer) {
    }
    public override void PreCustomerInteraction(Customer customer) {
    }

}
