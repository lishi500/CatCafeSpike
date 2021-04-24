using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FurnitureBase : MonoBehaviour
{
    public string furnitureName;
    public FurnitureType furnitureType;
    public bool canClick;
    public List<Cat> interactingCats;
    public List<Customer> interactingCustomer;
    public InteractPoint[] interactPoints;
    public delegate void FurnitureCatInteractionEndEvent(FurnitureBase task, Cat cat);
    public event FurnitureCatInteractionEndEvent notifyCatInteractionEnd;
    public delegate void FurnitureCustomerInteractionEndEvent(FurnitureBase task, Customer cat);
    public event FurnitureCustomerInteractionEndEvent notifyCustomerInteractionEnd;
   
    protected virtual void OnMouseUpAsButton() {
        if (canClick) {
            OnUserClick();
        }
    }

    protected abstract void OnUserClick();

    public abstract bool CanCatInteract(Cat cat);
    public abstract void PreCatInteraction(Cat cat);
    public abstract void CatInteraction(Cat cat);
    public abstract void InteractionEnd(Cat cat);


    public abstract bool CanCustomerInteract(Customer customer);
    public abstract void PreCustomerInteraction(Customer customer);
    public abstract void CustomerInteraction(Customer customer);
    public abstract void InteractionEnd(Customer customer);

    public InteractPoint ReserveInteractionPoint(Cat cat) {
        foreach (InteractPoint interact in interactPoints) {
            if (interact.CanReserve()) {
                interact.Reserve(cat);
                return interact;
            }
        }
        return null;
    }

    public InteractPoint ReserveInteractionPoint(Customer customer) {
        foreach (InteractPoint interact in interactPoints) {
            if (interact.CanReserve()) {
                interact.Reserve(customer);
                return interact;
            }
        }
        return null;
    }

    public InteractPoint GetOccupiedPoint(Cat cat) {
        foreach (InteractPoint interact in interactPoints) {
            if (interact.occupyCat == cat) {
                return interact;
            }
        }
        return null;
    }

    public InteractPoint GetReservedPoint(Cat cat) {
        foreach (InteractPoint interact in interactPoints) {
            if (interact.reserveCat == cat) {
                return interact;
            }
        }

        return null;
    }

    public virtual void NotifyEnd(Cat cat) {
        if (notifyCatInteractionEnd != null) {
            notifyCatInteractionEnd(this, cat);
        }
    }

    public virtual void NotifyEnd(Customer customer) {
        if (notifyCustomerInteractionEnd != null) {
            notifyCustomerInteractionEnd(this, customer);
        }
    }

    public virtual void Awake()
    {
        interactPoints = GetComponentsInChildren<InteractPoint>();
    }
}
