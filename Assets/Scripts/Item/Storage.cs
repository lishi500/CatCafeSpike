using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Storage
{
    // TODO need secure
    private long m_coin;
    public long FishCoin {
        get { return m_coin; }
    }
    private int m_heart;
    public int Heart {
        get { return m_heart; }
    }

    private List<StackItem> m_items;
    public List<StackItem> Bag {
        get { return m_items; }
    }


    public delegate void OnFishCoinNotEnough();
    public OnFishCoinNotEnough notifyFishCoinNotEnough;

    public bool WithdrawFishCoin(int amount) {
        if (FishCoin >= amount) {
            m_coin -= amount;
            return true;
        }
        if (notifyFishCoinNotEnough != null) {
            notifyFishCoinNotEnough();
        }
        return false;
    }

    public void DepositFishCoin(int amount) {
        if (amount >= 0) {
            m_coin += amount;
        }
    }

    void LoadItems() {
        m_items = new List<StackItem>();
    }
}
