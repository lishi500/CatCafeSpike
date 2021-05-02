using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cat : MonoBehaviour
{
    public Body body;
    public CatAttriburte attriburte;

    public abstract void OnTick5();

    public virtual void Start() {
        TickManager.Instance.notifyTimeTick5 += OnTick5;
    }

}
