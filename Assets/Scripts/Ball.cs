using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject poofPrefab;
    public GameObject[] stars;
    public GameObject winLoseController;
    public GameObject tutorial;

    private bool didWin = false;
    private int currentStarCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("star"))
        {
            //no cheating, you can not get the star if the ball is still in your hand
            if (GetComponent<BallInteractable>().isGrabbed())
            {
                print("Ball is grabbed");
            } else 
            {
                deleteStar(other.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            if (currentStarCount == stars.Length)
            {
                victory(collision.gameObject);
            }
            else
            {
                GetComponent<ResetPositionAfterGround>().ResetObject();
                resetStars();
            }
        }
    }

    void victory(GameObject goalTarget)
    {
        didWin = true;
        Object.Instantiate(poofPrefab, transform.position, Quaternion.LookRotation(Vector3.up));
        winLoseController.GetComponent<WinLose>().onVictory();

        if (tutorial != null)
        {
            tutorial.GetComponent<Tutorial>().onHitTarget();
        }
    }

    void deleteStar(GameObject star)
    {
        currentStarCount += 1;
        Object.Instantiate(poofPrefab, transform.position, Quaternion.LookRotation(Vector3.up));
        star.SetActive(false);
    }

    public void resetStars()
    {
        if (!didWin)
        {
            currentStarCount = 0;
            foreach (GameObject star in stars)
            {
                star.SetActive(true);
            }

            if (tutorial != null)
            {
                tutorial.GetComponent<Tutorial>().onBallReset();
            }
        }
    }
}
