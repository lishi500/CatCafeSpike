using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CatAIState 
{
    None,
    Idle,
    Wander,
    LickHair,
    Sleep,
    Eat,
    Drink,
    SelfPlay, // jump table, chase tail, jump tree
    PlayToy, // chase rat, play ball, 
    PlayWithCustomer,
    PlayWithCat
}
