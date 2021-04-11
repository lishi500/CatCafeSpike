using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPoint : MonoBehaviour
{
    public bool isOccupied = false;
    public bool isReserved;

    public Cat occupyCat;
    public Customer occupyCustomer;

    public Vector3 GetPosition() {
        return transform.position;
    }
    public void CatOccupy(Cat cat) {
        if (CanOccupy()) {
            Occupy();
            occupyCat = cat;
        }
    }
    public void CustomerOccupy(Customer customer) {
        if (CanOccupy()) {
            Occupy();
            occupyCustomer = customer;
        }
    }
    public bool CanOccupy() {
        return !isOccupied;
    }
    private void Occupy() {
        isOccupied = true;
        isReserved = false;
    }

    public bool CanReserve() {
        return !isOccupied && !isReserved;
    }

    public void Reserve() {
        if (!isOccupied && !isReserved) {
            isReserved = true;
        }
    }

    public void ReleasePoint() {
        isOccupied = false;
        isReserved = false;
        occupyCat = null;
        occupyCustomer = null;
    }

}
