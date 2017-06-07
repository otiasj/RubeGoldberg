using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteractable : InteractableWrappedItem
{
    public GameObject tutorial;

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
}
