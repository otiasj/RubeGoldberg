using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWrappedItem : InteractableItem
{
    public GameObject wrappedObject;

    protected override void freezePosition()
    {
        base.freezePosition();
        //rigidBody.detectCollisions = false;
    }

    protected override void unFreezePosition()
    {
        base.unFreezePosition();
        //rigidBody.detectCollisions = true;
    }

    protected override void setDefaultMaterial()
    {
        defaultMaterial = wrappedObject.GetComponent<Renderer>().material;
    }

    protected override void setGrabbedMaterial(Material grabbedMaterial)
    {
        wrappedObject.GetComponent<Renderer>().material = grabbedMaterial;
    }

    protected override void resetMaterial()
    {
        wrappedObject.GetComponent<Renderer>().material = defaultMaterial;
    }
}
