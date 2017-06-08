using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial3 : MonoBehaviour, Tutorial
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    private int state = 0;

    public void onTeleport()
    {
        if (state == 1)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(true);
            state++;
        }
    }

    public void onShowTeleport()
    {
        if (state == 0)
        {
            text1.SetActive(false);
            text2.SetActive(true);
            text3.SetActive(false);
            state++;
        }
    }

    public void onShowMenu()
    {
       
    }

    public void onPressLeftOrRight()
    {
       
    }

    public void onHitTarget()
    {
        state = -1;
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
    }

    public void onGrabBall()
    {

    }

    public void onBallReset()
    {

    }
}
