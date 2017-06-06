using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWrappedItem : InteractableItem
{
    public GameObject wrappedObject;
    public GameObject tutorial;

    protected override void freezePosition()
    {
        base.freezePosition();
    }

    protected override void unFreezePosition()
    {
        base.unFreezePosition();
    }

    protected override void setDefaultMaterial()
    {
        defaultMaterial = wrappedObject.GetComponent<Renderer>().material;
    }

    protected override void setGrabbedMaterial(Material grabbedMaterial)
    {
        wrappedObject.GetComponent<Renderer>().material = grabbedMaterial;
        
        if (tutorial != null)
        {
            tutorial.GetComponent<Tutorial>().onGrabBall();
        }
    }

    protected override void resetMaterial()
    {
        wrappedObject.GetComponent<Renderer>().material = defaultMaterial;
    }
}
