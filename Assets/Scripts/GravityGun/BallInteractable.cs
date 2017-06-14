using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteractable : InteractableWrappedItem
{
    public GameObject tutorial;
    public GameObject playerHead;
    public GameObject platform;
    public GameObject explanation1;

    private Bounds platformBounds;
    private Vector3 playerPosition;

    new void Start()
    {
        base.Start();
        platformBounds = platform.GetComponent<BoxCollider>().bounds;
        playerPosition = playerHead.transform.position;
    }

    public override void onGrabbedBy(GameObject anchorObject, Material grabbedMaterial)
    {
        base.onGrabbedBy(anchorObject, grabbedMaterial);

        //Make sure when we grab the ball that the stars are reset
        GetComponent<Ball>().resetStars();

        if (tutorial != null)
        {
            tutorial.GetComponent<Tutorial>().onGrabBall();
        }
    }

    public override void onDroppedBy(GameObject anchorObject)
    {
        base.onDroppedBy(anchorObject);

        if (platformBounds.Contains(playerHead.transform.position))
        {
            //ball throw is valid
        } else {
            //otherwise reset the ball and stars
            GetComponent<Ball>().resetStars();
            GetComponent<ResetPositionAfterGround>().ResetObject();

            //display warning message
            showExplanation();
            Invoke("hideExplanation", 3);
        }
    }

    private void showExplanation()
    {
        explanation1.SetActive(true);
    }

    private void hideExplanation()
    {
        explanation1.SetActive(false);
    }
}
