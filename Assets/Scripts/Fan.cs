using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour, Switchable
{
    public int degreesPerSecond;
    public int blowingForce;
    private Vector3 force;
    private bool isBlowing = false;

    void Update()
    {
        if (isBlowing)
        {
            transform.Rotate(0, 0, degreesPerSecond * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody != null && isBlowing)
        {
            force = this.transform.forward * blowingForce;
            //Debug.Log(GetComponent<Collider>().name + "<->" + other.name);
            //Debug.DrawRay(other.attachedRigidbody.position, force, Color.white);
            other.attachedRigidbody.AddForceAtPosition(force, other.attachedRigidbody.position);
        }
    }

    public void turnOnOff(bool isOn)
    {
        isBlowing = isOn;
    }

    public bool isRunning()
    {
        return isBlowing;
    }
}
