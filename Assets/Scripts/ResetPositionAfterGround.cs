using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionAfterGround : MonoBehaviour
{
    Vector3 initialPosition;

    void Start()
    {
        initialPosition = gameObject.transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Invoke("ResetObject", 1f);
            resetStars();
        }
    }

    public void ResetObject()
    { 
        gameObject.transform.position = initialPosition;
    }

    public void resetStars()
    {
        GetComponent<Ball>().resetStars();
    }
}
