using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1 : MonoBehaviour, Tutorial {
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject winLoseController;

    private Boolean tutorialIsOver = false;

    public void onGrabBall()
    {
        if (!tutorialIsOver)
        {
            text1.SetActive(false);
            text2.SetActive(true);
            text3.SetActive(false);
        }
    }

    public void onHitTarget()
    {
        tutorialIsOver = true;
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
    }

    public void onBallReset()
    {
        if (!tutorialIsOver)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(true);
        }
    }
}
