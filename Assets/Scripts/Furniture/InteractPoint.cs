using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPoint : MonoBehaviour
{
    public bool isOccupied = false;
    public bool isReserved;
    public Cat occupyCat;
    public Customer occupyCustomer;
    public Cat reserveCat;
    public Customer reserveCustomer;

    public Vector3 GetPosition() {
        return transform.position;
    }
    public void CatOccupy(Cat cat) {
        if (CanOccupy()) {
            Occupy(cat);
        }
    }
    public void CustomerOccupy(Customer customer) {
        if (CanOccupy()) {
            Occupy(customer);
        }
    }
    public bool CanOccupy() {
        return !isOccupied;
    }
    private void Occupy(Cat cat) {
        isOccupied = true;
        occupyCat = cat;
        ReleaseReserve();
    }

    private void Occupy(Customer customer) {
        isOccupied = true;
        occupyCustomer = customer;
        ReleaseReserve();
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

    public void ReleaseOccupy() {
        isOccupied = false;
        occupyCustomer = null;
        occupyCat = null;
    }

    public void ReleaseReserve() {
        isReserved = false;
        reserveCat = null;
        reserveCustomer = null;
    }

}
