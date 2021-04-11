using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBow : Furniture
{
    public int maxFood;
    public int currentFood;

    public override bool CanCatInteract() {
        return GetAvaiableInteractionPoint() != null;
    }

    public override bool CanCustomerInteract() {
        return false;
    }


    protected override void OnCatInteraction(Cat cat) {

    }

    protected override void OnCustomerInteraction(Customer customer) {
        
    }

    protected override void OnUserClick() {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
