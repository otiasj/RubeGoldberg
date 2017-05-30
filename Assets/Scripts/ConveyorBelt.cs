using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour {

    public float speed = 5f;

    //To make the texture move
    private Vector2 textureOffset = new Vector2(0f, 0f);
    private Material beltTexture;

    void Start()
    {
        beltTexture = GetComponent<Renderer>().material;
    }

    void Update()
    {
        textureOffset.Set(0, Time.time * speed);
        beltTexture.SetTextureOffset("_MainTex", textureOffset);
    }

    void OnCollisionStay(Collision collided)
    {
        //Debug.Log(GetComponent<Collider>().name + "<->" + collided.rigidbody.name);
        //Debug.DrawRay(collided.transform.position, transform.forward * speed, Color.white);
        //collided.rigidbody.MovePosition(collided.transform.position + transform.forward * Time.deltaTime * speed);
        collided.rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
