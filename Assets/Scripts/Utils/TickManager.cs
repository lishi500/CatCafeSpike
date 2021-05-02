using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickManager : Singleton<TickManager>
{
    public bool isPause = false;
    private float timer1;
    private float timer5;
    //private GameTime currentTime;

    private static int MINUTE_PER_TICK = 120;

    public delegate void TimeTickEvent();
    public event TimeTickEvent notifyTimeTick1;
    public event TimeTickEvent notifyTimeTick5;
    //public GameTime CurrentTime {
    //    get { return currentTime; }
    //}

    public void Pause() {
        isPause = true;
    }

    public void Resume() {
        isPause = false;
    }
    
    private void Tick1() {
        //if (currentTime != null) {
        //    currentTime.AddMinutes(MINUTE_PER_TICK);
        //}
        //Debug.Log(Time.time);

        //Debug.Log("Tick " + currentTime.toString());
        if (notifyTimeTick1 != null) {
            //Debug.Log("notifyTimeTick");
            notifyTimeTick1();
        }
    }

    private void Tick5() {
        if (notifyTimeTick5 != null) {
            Debug.Log("notifyTimeTick5");

            notifyTimeTick5();
        }
    }

    private void LateUpdate()
    {
        if (!isPause) {
            timer1 += Time.deltaTime;
            timer5 += Time.deltaTime;
            if (timer1 >= 1) {
                Tick1();
                timer1 -= 1;
            }
            if (timer5 >= 5) {
                Tick5();
                timer5 -= 5;
            }
        }
       
    }

    void Start() {
        //currentTime = new GameTime();
    }
   
}
