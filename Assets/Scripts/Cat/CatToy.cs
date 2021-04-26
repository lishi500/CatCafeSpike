using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CatToy : MonoBehaviour
{
    public ToyType toyType;
    public abstract void PlayBy(Cat cat);
}
