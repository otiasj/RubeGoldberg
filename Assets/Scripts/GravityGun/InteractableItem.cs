using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : InteractableBase
{
    public bool freezeOnDrop = true;

    protected Rigidbody rigidBody;
    protected bool currentlyInteracting;
    protected uint itemId;

    // velocity_obj = (hand_pos - obj_pos) * velocityFactor / rigidbody.mass
    private float velocityFactor = 20000f;
    private Vector3 posDelta; // posDelta = (hand_pos - obj_pos)

    private float rotationFactor = 600f;
    private Quaternion rotationDelta;
    private float angle;
    private Vector3 axis;
    protected Material defaultMaterial;

    // The controller this object is picked up by
    private GameObject anchorObject;

    // The point at which the object was grabbed when picked up
    private Transform interactionPoint;

    // Use this for initialization
    protected void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        interactionPoint = new GameObject().transform;
        velocityFactor /= rigidBody.mass;
        rotationFactor /= rigidBody.mass;
        setDefaultMaterial();
        if (freezeOnDrop)
        {
            freezePosition();
        }
    }

    protected virtual void setDefaultMaterial()
    {
        defaultMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (anchorObject != null && currentlyInteracting)
        {
            posDelta = anchorObject.transform.position - interactionPoint.position;
            this.rigidBody.velocity = posDelta * velocityFactor * Time.fixedDeltaTime;

            rotationDelta = anchorObject.transform.rotation * Quaternion.Inverse(interactionPoint.rotation);
            rotationDelta.ToAngleAxis(out angle, out axis);

            if (angle > 180)
            {
                angle -= 360;
            }

            this.rigidBody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * rotationFactor;
        }
    }

    public override void onGrabbedBy(GameObject anchorObject, Material grabbedMaterial)
    {
        setPositionFrom(anchorObject);
        setGrabbedMaterial(grabbedMaterial);
        unFreezePosition();
    }

    public override bool isGrabbed() {
        return currentlyInteracting;
    }

    protected virtual void setPositionFrom(GameObject anchorObject)
    {
        this.anchorObject = anchorObject;
        currentlyInteracting = true;
        interactionPoint.position = this.anchorObject.transform.position;
        interactionPoint.rotation = this.anchorObject.transform.rotation;
        interactionPoint.SetParent(transform, true);
    }

    protected virtual void unFreezePosition()
    {
        this.rigidBody.constraints = RigidbodyConstraints.None;
        this.rigidBody.freezeRotation = false;
        this.rigidBody.isKinematic = false;
    }

    public override void onDroppedBy(GameObject anchorObject)
    {
        setInactive(anchorObject);
        currentlyInteracting = false;
    }

    protected virtual void setInactive(GameObject anchorObject)
    {
        if (anchorObject == this.anchorObject)
        {
            currentlyInteracting = false;
            this.anchorObject = null;
            resetMaterial();
            if (freezeOnDrop)
            {
                freezePosition();
            }
        }
    }

    protected virtual void freezePosition()
    {
        this.rigidBody.velocity = Vector3.zero;
        this.rigidBody.angularVelocity = Vector3.zero;
        this.rigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
        this.rigidBody.freezeRotation = true;
        this.rigidBody.isKinematic = true;
    }

    protected virtual void setGrabbedMaterial(Material grabbedMaterial)
    {
        GetComponent<Renderer>().material = grabbedMaterial;
    }

    protected virtual void resetMaterial()
    {
        GetComponent<Renderer>().material = defaultMaterial;
    }

    public bool IsInteracting()
    {
        return currentlyInteracting;
    }

    private void OnDestroy()
    {
        // Destroy the empty game object associated with interaction point
        if (interactionPoint)
        {
            Destroy(interactionPoint.gameObject);
        }
    }
}
