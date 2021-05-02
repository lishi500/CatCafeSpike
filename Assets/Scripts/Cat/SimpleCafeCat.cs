using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCafeCat : Cat {

    public void BodyStatusProgress() {
        Debug.Log("BodyStatusProgress");
        body.ConsumeBodyAttribute(body.hunger, body.hungryConsumptionRate);
        body.ConsumeBodyAttribute(body.thirst, body.thirstConsumptionRate);
        body.ConsumeBodyAttribute(body.mood, body.moodConsumptionRate);
        body.ConsumeBodyAttribute(body.energy, body.energyConsumptionRate);
        body.ConsumeBodyAttribute(body.tiredness, body.hungryConsumptionRate, true);
    }
    public override void OnTick5() {
        BodyStatusProgress();
    }
}
