using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    private Vector3 initialPosition;
    private float initialRotation;
    private float rotationY;

    // Use this for initialization
    void Start () {
        initialPosition = transform.position;
        initialRotation = transform.rotation.y;
    }
	
	// Update is called once per frame
	void Update () {
        //rotate the star
        rotationY += initialRotation + Time.deltaTime * 100;
        transform.rotation = Quaternion.Euler(0, rotationY, 0);

        //translate up and down
        transform.position = initialPosition + new Vector3(0, Mathf.Sin(Time.time) / 8, 0);
    }
}
