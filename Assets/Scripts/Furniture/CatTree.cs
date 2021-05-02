using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTree : CatFurniture
{
    public override bool CanCatInteract(Cat cat) {
        return true;
    }

    public override void CatInteraction(Cat cat) {
        throw new System.NotImplementedException();
    }

    protected override void OnUserClick() {
    }
  
}
