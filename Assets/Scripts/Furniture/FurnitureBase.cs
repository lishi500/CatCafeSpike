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

    protected virtual void OnMouseUpAsButton() {
        if (canClick) {
            OnUserClick();
        }
    }

    protected abstract void OnUserClick();
    public abstract void CatInteraction(Cat cat);
    public abstract void CustomerInteraction(Customer customer);


    public abstract bool CanCatInteract(Cat cat);
    public abstract bool CanCustomerInteract(Customer customer);

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

    void Awake()
    {
        interactPoints = GetComponentsInChildren<InteractPoint>();
    }
}
