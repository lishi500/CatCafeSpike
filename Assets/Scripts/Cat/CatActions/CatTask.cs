using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CatTask : Task
{
    public Cat cat;
    public virtual void SetTaskTarget(GameObject obj, Vector3 tar, Cat cat) {
        interactionObject = obj;
        targetPosition = tar;
        this.cat = cat;
    }
}
