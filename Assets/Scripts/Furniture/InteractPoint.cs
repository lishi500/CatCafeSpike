using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPoint : MonoBehaviour
{
    public bool isOccupied = false;
    public bool isReserved;

    public Cat reserveCat;
    public Customer reserveCustomer;

    public Vector3 GetPosition() {
        return transform.position;
    }
    public void CatOccupy() {
        if (CanOccupy()) {
            Occupy();
        }
    }
    public void CustomerOccupy() {
        if (CanOccupy()) {
            Occupy();
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
        return !isReserved;
    }

    public void Reserve(Cat cat) {
        if (CanReserve()) {
            isReserved = true;
            reserveCat = cat;
        }
    }
    public void Reserve(Customer customer) {
        if (CanReserve()) {
            isReserved = true;
            reserveCustomer = customer;
        }
    }

    public void ReleasePoint() {
        isOccupied = false;
        isReserved = false;
        reserveCat = null;
        reserveCustomer = null;
    }

}
