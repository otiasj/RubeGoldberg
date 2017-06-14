using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour, Switchable {

    public float speed = 5f;
    public bool isRampRunning = false;

    //To make the texture move
    private Vector2 textureOffset = new Vector2(0f, 0f);
    private Material beltTexture;

    void Start()
    {
        beltTexture = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (isRampRunning)
        {
            textureOffset.Set(0, Time.time * speed);
            beltTexture.SetTextureOffset("_MainTex", textureOffset);
        }
    }

    void OnCollisionStay(Collision collided)
    {
        //Debug.Log(GetComponent<Collider>().name + "<->" + collided.rigidbody.name);
        //Debug.DrawRay(collided.transform.position, transform.forward * speed, Color.white);
        //collided.rigidbody.MovePosition(collided.transform.position + transform.forward * Time.deltaTime * speed);

        if (isRampRunning)
        {
            collided.rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
    }

    public void turnOnOff(bool isOn)
    {
        isRampRunning = isOn;
        this.gameObject.GetComponent<BoxCollider>().enabled = isOn;
    }

    public bool isRunning()
    {
        return isRampRunning;
    }
}
