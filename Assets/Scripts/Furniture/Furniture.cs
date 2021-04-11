using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Furniture : MonoBehaviour
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
    protected abstract void OnCatInteraction(Cat cat);
    protected abstract void OnCustomerInteraction(Customer customer);

    public abstract bool CanCatInteract();
    public abstract bool CanCustomerInteract();

    public InteractPoint GetAvaiableInteractionPoint() {
        foreach (InteractPoint interact in interactPoints) {
            if (interact.CanReserve()) {
                return interact;
            }
        }
        return null;
    }

    void Start()
    {
        interactPoints = GetComponentsInChildren<InteractPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
