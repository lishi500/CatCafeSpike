using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InterruptType 
{
    ByOtherCat,
    ByPlayerAction,
    ByCustomer,

    Distracted,

    NoAvailablePoint,
    PointOccupied, // interaction point been using by other cat
    NoObjectFound,

    NotEnoughResources, // no food in bow
    PathBlocked,
    TooFarFromObject
}
